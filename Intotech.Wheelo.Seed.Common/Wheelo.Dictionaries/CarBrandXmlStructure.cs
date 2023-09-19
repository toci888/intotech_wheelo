using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class select
{

    private selectOption[] optionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("option")]
    public selectOption[] option
    {
        get
        {
            return this.optionField;
        }
        set
        {
            this.optionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class selectOption
{

    private ushort valueField;

    private string valueField1;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField1;
        }
        set
        {
            this.valueField1 = value;
        }
    }
}


namespace Intotech.Wheelo.Seed.Common.Wheelo.Dictionaries
{
    public class CarBrandXmlStructure
    {
    }
}
