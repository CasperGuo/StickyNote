using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

namespace StickyNotes
{
  public class Note
  {
    public string ID;
    public string Text;
    
    public Size WindowSize;
    public Point WindowLocation;

    public Note ()
    {
      ID = Guid.NewGuid().ToString();
      
      WindowSize = new Size(255, 255);
      WindowLocation = new Point(255, 255);
    }

    public Note(string text) : this()
    {
      Text = text;
    }
  }

  public class Settings
  {
    [XmlIgnore]
    public Color BackgroundColor { get; set; }
    [XmlElement("BackgroundColor")]
    public int BackgroundColorXml
    {
      get { return BackgroundColor.ToArgb(); }
      set { BackgroundColor = Color.FromArgb(value); }
    }


    [XmlIgnore]
    public Color ForegroundColor { get; set; }
    [XmlElement("ForegroundColor")]
    public int ForegroundColorXml
    {
      get { return ForegroundColor.ToArgb(); }
      set { ForegroundColor = Color.FromArgb(value); }
    }

    public string FontName;
    public int FontSize;

    public List<Note> Notes;

    public Settings()
    {
      Notes = new List<Note>();
      FontName = "Consolas";
      FontSize = 14;

      ForegroundColor = Color.FromArgb(255, 0, 0 ,0);
      BackgroundColor = Color.FromArgb(255, 255, 255, 192);
    }

    public static Settings LoadFromFile(string filename)
    {
      try
      {
        var serializer = new XmlSerializer(typeof(Settings));
        using (var reader = XmlReader.Create(filename))
        {
          var settings = (Settings)serializer.Deserialize(reader);
          return settings;
        }
      } catch
      {
        return new Settings();
      }
    }

    public void SaveToFile(string filename)
    {
      var serializer = new XmlSerializer(this.GetType());
      using (var writer = XmlWriter.Create(filename))
      {
        serializer.Serialize(writer, this);
      }
    }
  }
}
