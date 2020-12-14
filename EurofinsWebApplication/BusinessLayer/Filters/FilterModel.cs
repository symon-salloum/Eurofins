using System;

namespace BusinessLayer.Filters
{
    public class FilterModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsStricktFilter { get; set; }

        public bool IsValidFilter() => !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description);

    }
}

