﻿using System.Collections.Generic;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class Caption : OwnerCreatorIdAndCreator
    {
        public virtual ICollection<LocalizedCaption> LocalizedCaptions { get; set; }

       // public virtual ICollection<Photo> AccommodationPhotos { get; set; }
    }
}