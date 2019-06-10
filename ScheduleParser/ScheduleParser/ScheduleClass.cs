using System.Xml.Serialization;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class MBS_XML
{

    private MBS_XMLData[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Data", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public MBS_XMLData[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class MBS_XMLData
{

    private string itemNumField;

    private string subItemNumField;

    private string itemStartDateField;

    private string itemEndDateField;

    private string categoryField;

    private string groupField;

    private string subGroupField;

    private string subHeadingField;

    private string itemTypeField;

    private string feeTypeField;

    private string providerTypeField;

    private string newItemField;

    private string itemChangeField;

    private string anaesChangeField;

    private string descriptorChangeField;

    private string feeChangeField;

    private string eMSNChangeField;

    private string eMSNCapField;

    private string benefitTypeField;

    private string benefitStartDateField;

    private string feeStartDateField;

    private string scheduleFeeField;

    private string benefit75Field;

    private string benefit85Field;

    private string benefit100Field;

    private string basicUnitsField;

    private string eMSNStartDateField;

    private string eMSNEndDateField;

    private string eMSNFixedCapAmountField;

    private string eMSNMaximumCapField;

    private string eMSNPercentageCapField;

    private string eMSNDescriptionField;

    private string eMSNChangeDateField;

    private string anaesField;

    private string derivedFeeStartDateField;

    private string derivedFeeField;

    private string descriptionStartDateField;

    private string descriptionField;

    private string qFEStartDateField;

    private string qFEEndDateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ItemNum
    {
        get
        {
            return this.itemNumField;
        }
        set
        {
            this.itemNumField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SubItemNum
    {
        get
        {
            return this.subItemNumField;
        }
        set
        {
            this.subItemNumField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ItemStartDate
    {
        get
        {
            return this.itemStartDateField;
        }
        set
        {
            this.itemStartDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ItemEndDate
    {
        get
        {
            return this.itemEndDateField;
        }
        set
        {
            this.itemEndDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Category
    {
        get
        {
            return this.categoryField;
        }
        set
        {
            this.categoryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Group
    {
        get
        {
            return this.groupField;
        }
        set
        {
            this.groupField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SubGroup
    {
        get
        {
            return this.subGroupField;
        }
        set
        {
            this.subGroupField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string SubHeading
    {
        get
        {
            return this.subHeadingField;
        }
        set
        {
            this.subHeadingField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ItemType
    {
        get
        {
            return this.itemTypeField;
        }
        set
        {
            this.itemTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string FeeType
    {
        get
        {
            return this.feeTypeField;
        }
        set
        {
            this.feeTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ProviderType
    {
        get
        {
            return this.providerTypeField;
        }
        set
        {
            this.providerTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string NewItem
    {
        get
        {
            return this.newItemField;
        }
        set
        {
            this.newItemField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ItemChange
    {
        get
        {
            return this.itemChangeField;
        }
        set
        {
            this.itemChangeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string AnaesChange
    {
        get
        {
            return this.anaesChangeField;
        }
        set
        {
            this.anaesChangeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DescriptorChange
    {
        get
        {
            return this.descriptorChangeField;
        }
        set
        {
            this.descriptorChangeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string FeeChange
    {
        get
        {
            return this.feeChangeField;
        }
        set
        {
            this.feeChangeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNChange
    {
        get
        {
            return this.eMSNChangeField;
        }
        set
        {
            this.eMSNChangeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNCap
    {
        get
        {
            return this.eMSNCapField;
        }
        set
        {
            this.eMSNCapField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string BenefitType
    {
        get
        {
            return this.benefitTypeField;
        }
        set
        {
            this.benefitTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string BenefitStartDate
    {
        get
        {
            return this.benefitStartDateField;
        }
        set
        {
            this.benefitStartDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string FeeStartDate
    {
        get
        {
            return this.feeStartDateField;
        }
        set
        {
            this.feeStartDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ScheduleFee
    {
        get
        {
            return this.scheduleFeeField;
        }
        set
        {
            this.scheduleFeeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Benefit75
    {
        get
        {
            return this.benefit75Field;
        }
        set
        {
            this.benefit75Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Benefit85
    {
        get
        {
            return this.benefit85Field;
        }
        set
        {
            this.benefit85Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Benefit100
    {
        get
        {
            return this.benefit100Field;
        }
        set
        {
            this.benefit100Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string BasicUnits
    {
        get
        {
            return this.basicUnitsField;
        }
        set
        {
            this.basicUnitsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNStartDate
    {
        get
        {
            return this.eMSNStartDateField;
        }
        set
        {
            this.eMSNStartDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNEndDate
    {
        get
        {
            return this.eMSNEndDateField;
        }
        set
        {
            this.eMSNEndDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNFixedCapAmount
    {
        get
        {
            return this.eMSNFixedCapAmountField;
        }
        set
        {
            this.eMSNFixedCapAmountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNMaximumCap
    {
        get
        {
            return this.eMSNMaximumCapField;
        }
        set
        {
            this.eMSNMaximumCapField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNPercentageCap
    {
        get
        {
            return this.eMSNPercentageCapField;
        }
        set
        {
            this.eMSNPercentageCapField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNDescription
    {
        get
        {
            return this.eMSNDescriptionField;
        }
        set
        {
            this.eMSNDescriptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EMSNChangeDate
    {
        get
        {
            return this.eMSNChangeDateField;
        }
        set
        {
            this.eMSNChangeDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Anaes
    {
        get
        {
            return this.anaesField;
        }
        set
        {
            this.anaesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DerivedFeeStartDate
    {
        get
        {
            return this.derivedFeeStartDateField;
        }
        set
        {
            this.derivedFeeStartDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DerivedFee
    {
        get
        {
            return this.derivedFeeField;
        }
        set
        {
            this.derivedFeeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DescriptionStartDate
    {
        get
        {
            return this.descriptionStartDateField;
        }
        set
        {
            this.descriptionStartDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string QFEStartDate
    {
        get
        {
            return this.qFEStartDateField;
        }
        set
        {
            this.qFEStartDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string QFEEndDate
    {
        get
        {
            return this.qFEEndDateField;
        }
        set
        {
            this.qFEEndDateField = value;
        }
    }
}
