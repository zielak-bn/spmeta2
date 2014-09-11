﻿using System;

namespace SPMeta2.Definitions
{
    /// <summary>
    /// Base definition for all SharePoint artifacts to be defined and deployed.
    /// </summary>
    /// 
    [Serializable]
    public abstract class DefinitionBase : ICloneable
    {
        #region constructors

        protected DefinitionBase()
        {
            RequireSelfProcessing = true;
        }

        #endregion

        #region properties

        /// <summary>
        /// Internal usage only. Will be removed in future versions of SPMeta2 library.
        /// </summary>
        [Obsolete]
        public virtual bool RequireSelfProcessing { get; set; }

        #endregion

        #region methods

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}
