﻿using System;
using System.Collections.Generic;

namespace BookStoreApp.Data;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Year { get; set; }

    public string Isbn { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public string? Image { get; set; }

    public double? Price { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }
}
