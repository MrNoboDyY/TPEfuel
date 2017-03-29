
/*******************************************************************************************
 * Copyright (C) 2017 Docapost Applicam, Inc - All Rights Reserved
 * 
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential.
 *
 * Written by Francis-Black EWANE <fb.ewane@docapost-applicam.com>, January 2017
 *********************************************************************************************/

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace GestionTPE.Model
{
    /// <summary>
    /// Abstract base class that implements the <see cref=" INotifyPropertyChanged"/> interface.
    /// </summary>
    [Serializable]
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <summary>
        /// Updates the property and call the <see cref="PropertyChanged"/> event only of the property has changed.
        /// </summary>
        /// <typeparam name="TField">The property type</typeparam>
        /// <param name="currentFieldValue">The current value of the property (the back-end property)</param>
        /// <param name="newFieldValue">The new value of the property (the value)</param>
        /// <param name="propertyName">The name of the property. Optional (Known at compile time)</param>
        /// <returns><see langword="true"/> if property has changed, otherwise <see langword="false"/></returns>
        protected virtual bool SetField<TField>(ref TField currentFieldValue, TField newFieldValue, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(currentFieldValue, newFieldValue)) return false;

            TField oldValue = currentFieldValue;
            currentFieldValue = newFieldValue;

            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Raise the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The property name that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName) 
        {
            var handler = PropertyChanged;
            if(handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));

        }

        /// <summary>
        /// Event raised when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
