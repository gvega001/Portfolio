// Portfolio.Shared/Models/Resume.cs
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Portfolio.Shared.Models
{
    [Serializable]
    public class Resume
    {
        [JsonPropertyName("basics")]
        public Basics? Basics { get; set; }
        [JsonPropertyName("work")]
        public List<Work>? Work { get; set; }
        [JsonPropertyName("education")]
        public List<Education> Education { get; set; }
        [JsonPropertyName("skills")]
        public List<Skill> Skills { get; set; }
        [JsonPropertyName("projects")]
        public List<Project> Projects { get; set; }
        [JsonPropertyName("certifications")]
        public List<Certification> Certifications { get; set; }
        [JsonPropertyName("languages")]
        public List<Language> Languages { get; set; }
        [JsonPropertyName("interests")]
        public List<Interest> Interests { get; set; }
    }
    [Serializable]
    public class Basics
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("picture")]
        public string Picture { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("website")]
        public string Website { get; set; }
        [JsonPropertyName("summary")]
        public string Summary { get; set; }
        [JsonPropertyName("location")]
        public Location Location { get; set; }
        [JsonPropertyName("profiles")]
        public List<Profile> Profiles { get; set; }
    }


    public class Location
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
    }

    public class Profile
    {
        public string Network { get; set; }
        public string Username { get; set; }
        public string Url { get; set; }
    }

    public class Work
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Summary { get; set; }
    }

    public class Education
    {
        public string Institution { get; set; }
        public string Area { get; set; }
        public string StudyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class Skill
    {
        public string Name { get; set; }
        public List<string> Keywords { get; set; }
    }

    public class Project
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Summary { get; set; }
    }

    public class Certification
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Issuer { get; set; }
    }

    public class Language
    {
        public string Language_ { get; set; }
        public string Fluency { get; set; }
    }

    public class Interest
    {
        public string Name { get; set; }
        public List<string> Keywords { get; set; }
    }
}
