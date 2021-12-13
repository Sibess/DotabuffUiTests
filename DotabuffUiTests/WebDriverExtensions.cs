﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DotabuffUiTests
{
    public static class WebDriverExtensions
    {
        public static WebDriverWait GetWait(this IWebDriver driver, TimeSpan timeout) => new WebDriverWait(driver, timeout);
    }
}
