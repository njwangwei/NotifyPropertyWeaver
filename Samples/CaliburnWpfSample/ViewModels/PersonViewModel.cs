﻿using Caliburn.PresentationFramework;

namespace CaliburnWpfSample.ViewModels
{

	public class PersonViewModel : PropertyChangedBase
	{
	    public string GivenNames;
	    public string FamilyName;

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", GivenNames, FamilyName);
            }
        }

	}
}
