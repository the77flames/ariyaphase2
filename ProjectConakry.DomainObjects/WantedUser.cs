
using System;
using MongoDB.Bson;
namespace ProjectConakry.DomainObjects
{
    public class WantedUser : Customer, IVoteable
    {
        public ObjectId CustomerId { get; set; }
        public string EntryVideoFileName { get; set; }
        public string EntryVideoContentType { get; set; }
        public string BirthPlace { get; set; }
        public string StageName { get; set; }
        public string BriefIndustryExperience { get; set; }
        public string FirstComedianInspiration { get; set; }
        public string SecondComedianInspiration { get; set; }
        public string Nationality { get; set; }
        public byte[] EntryVideo { get; set; }
        public int CommitmentToProcessScore { get; set; }
        public int CommunicationSkillsScore { get; set; }
        public int DressingSenseScore { get; set; }
        public int KnowledgeOfComedyScore { get; set; }
        public int RelationshipWithPeopleScore { get; set; }
        public int RetentiveMemoryScore { get; set; }
        public int StageEtiqueteScore { get; set; }
        public int SelfDisciplineScore { get; set; }
        public int SelfMotivationScore { get; set; }
        public int StagePresenceScore { get; set; }
        public bool AgreedToDisclaimer { get; set; }
        public bool AgreedToTermsOfService { get; set; }
        public bool Subscribed { get; set; }
        public int TotalVotes { get; set; }
    }
}