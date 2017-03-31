using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GestionTPE.Managers
{
    //public static class RegexValidation : ValidationRule
    //{
    //    static RegexValidation()
    //    {
    //        RegexTextProperty = DependencyProperty.RegisterAttached(
    //          "RegexText",
    //          typeof(string),
    //          typeof(RegexValidation),
    //          new UIPropertyMetadata(null, OnAttachedPropetyChanged));

    //        ErrorMessageProperty = DependencyProperty.RegisterAttached("ErrorMessage",
    //            typeof(string),
    //            typeof(RegexValidation),
    //            new UIPropertyMetadata(null, OnAttachedPropertyChanged));
    //    }

    //    public static readonly DependencyProperty ErrorMessageProperty;

    //    public static string GetErrorMessage(TextBox textbox)
    //    {
    //        return textbox.GetValue(ErrorMessageProperty) as string;
    //    }

    //    public static void SetErrorMessage(TextBox textbox, string value)
    //    {
    //        textbox.SetValue(ErrorMessageProperty, value);
    //    }

    //    public static readonly DependencyProperty RegexTextProperty;

    //    public static string GetRegexText(TextBox textbox)
    //    {
    //        return textbox.GetValue(RegexTextProperty) as string;
    //    }

    //    public static void SetRegexText(TextBox textbox, string value)
    //    {
    //        textbox.SetValue(RegexTextProperty, value);
    //    }


    //    static void OnAttachedPropertyChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    //    {
    //        TextBox textbox = depObj as TextBox;
    //        if (textbox == null)
    //        {
    //            throw new InvalidOperationException("le Regexvalidator s'utilise avec une textbox");
    //            VerifyRegexValidationRule(textbox);
    //        }
    //    }

    //    static RegexValidationRule GetRegexValidationRuleForTextBox(TextBox textbox)
    //   {
    //       if (!textbox.IsInitialized)
    //       { EventHandler callback}
    //   }

       

    //    private string regexVal;
    //    public string Regexval
    //    {
    //        get
    //        {
    //            return regexVal;
    //        }
    //        set
    //        {
    //            regexVal = value;
    //        }
    //    }


    //    private string errormessage;
    //    public string Errormessage
    //    {
    //        get
    //        {
    //            return errormessage;
    //        }
    //        set
    //        {
    //            errormessage = value;
    //        }
    //    }





    //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    //    {
    //        ValidationResult result = new ValidationResult(true, null);
    //        try
    //        {
    //            Regex tempReg = new Regex(Regexval);
    //            if (!string.IsNullOrEmpty((string)value)) 
    //            {
    //                if (!tempReg.Match(value as string).Success)
    //                {
    //                    result = new ValidationResult(false, Errormessage.ToString());
    //                }
    //            }
    //            return result;
    //        }
    //        catch (Exception ex)
    //        {
    //            result = new ValidationResult(false, ex.Message.ToString());
    //            return result;
    //        }
    //    }

    //}
}
