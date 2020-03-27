using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmAPI.Models
{
    public class Schrijver : IPersoon
    {
            private DateTime _geboortedatum;
            private string _naam;
            private int _leeftijd;

            public DateTime Geboortedatum
            {
                get { return _geboortedatum; }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentException("Een schrijver moet een geboortedatum hebben");
                    }
                    _geboortedatum = value;
                }
            }
            public DateTime? Sterfdatum
            {
                get;
                set;
            }
            public string Naam
            {
                get { return _naam; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Een schrijver moet een naam hebben");
                    }
                    _naam = value;
                }
            }

            public string Geboortestad
            {
                get;
                set;
            }

            private void SetLeeftijd()
            {
                if (Sterfdatum != null)
                {
                    var date = Sterfdatum.Value.Date;
                    _leeftijd = date.Year - _geboortedatum.Year;
                    if (_geboortedatum.Date > date.AddYears(-_leeftijd)) _leeftijd--;
                }
                else
                {
                    var today = DateTime.Today;
                    _leeftijd = today.Year - _geboortedatum.Year;
                    if (_geboortedatum.Date > today.AddYears(-_leeftijd)) _leeftijd--;
                }
            }

            public int GetLeeftijd()
            {
                return _leeftijd;
            }


            public Schrijver(string naam, DateTime geboortedatum, string? geboortestad = "niet bekend", DateTime? sterfdatum = null)
            {
                Naam = naam;
                Geboortedatum = geboortedatum;
                Geboortestad = geboortestad;
                Sterfdatum = sterfdatum;
                SetLeeftijd();
            }

        }
    }
