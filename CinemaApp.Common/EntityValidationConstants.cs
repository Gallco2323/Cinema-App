﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Movie
        {
            public const int TitleMaxLength = 50;
            public const int GenreMinLength = 5;
            public const string ReleaseDateFormat = "MM/yyyy";
            public const int GenreMaxLength = 50;
            public const int DurationMinValue = 1;
            public const int DurationMaxValue = 9999;
            public const int DirectorMaxLength = 50;
            public const int DirectorMinLength = 5;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

        } 

        public static class Cinema
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 5;
            public const int LocationMaxLength = 50;
            public const int LocationMinLength = 5;
        }
    }
}
