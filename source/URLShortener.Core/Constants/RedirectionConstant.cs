using System;
using System.Collections.Generic;
using System.Text;

public partial class Constants
{
    public static class Redirection
    {
        public const int OriginalURLMinimumLength = 3;
        public const int OriginalURLMaximumLength = 2083;
        public const bool OriginalURLRequired = true;

        public const int SlugMinimumLength = 3;
        public const int SlugMaximumLength = 2000;
        public const bool SlugRequired = true;

    }
}
