﻿using System;
using System.Xml.Linq;
using Microsoft.SharePoint;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Fields;
using SPMeta2.Enumerations;
using SPMeta2.Utils;

namespace SPMeta2.SSOM.ModelHandlers.Fields
{
    public class DateTimeFieldModelHandler : FieldModelHandler
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(DateTimeFieldDefinition); }
        }

        protected override Type GetTargetFieldType(FieldDefinition model)
        {
            return typeof(SPFieldDateTime);
        }

        #endregion

        #region methods

        protected override void ProcessFieldProperties(SPField field, FieldDefinition fieldModel)
        {
            // let base setting be setup
            base.ProcessFieldProperties(field, fieldModel);

        }

        protected override void ProcessSPFieldXElement(XElement fieldTemplate, FieldDefinition fieldModel)
        {
            base.ProcessSPFieldXElement(fieldTemplate, fieldModel);

            var typedFieldModel = fieldModel.WithAssertAndCast<DateTimeFieldDefinition>("model", value => value.RequireNotNull());

            if (!string.IsNullOrEmpty(typedFieldModel.CalendarType))
            {
                var value = (SPCalendarType)Enum.Parse(typeof(SPCalendarType), typedFieldModel.CalendarType);
                fieldTemplate.SetAttribute(BuiltInFieldAttributes.CalendarType, (int)value);
            }

            if (!string.IsNullOrEmpty(typedFieldModel.DisplayFormat))
                fieldTemplate.SetAttribute(BuiltInFieldAttributes.DisplayFormat, typedFieldModel.DisplayFormat);

            if (!string.IsNullOrEmpty(typedFieldModel.FriendlyDisplayFormat))
                fieldTemplate.SetAttribute(BuiltInFieldAttributes.FriendlyDisplayFormat, typedFieldModel.FriendlyDisplayFormat);
        }

        #endregion
    }
}
