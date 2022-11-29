﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Web.Data;

public class Person
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public int NationalityId { get; set; }

    [Required]
    public Nationality Nationality { get; set; } = null!;
}
