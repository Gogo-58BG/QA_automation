using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2.Extentions
{
    public static class ElementExtentions
    {
        public static void Type(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }
    }
}
