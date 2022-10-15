﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Enums
{
    public enum Gender
    {
        [BsonRepresentation(BsonType.String)]
        Male,
        [BsonRepresentation(BsonType.String)]
        Female,
        [BsonRepresentation(BsonType.String)]
        Other
    } 
    public enum MaritalStatus
    {
        [BsonRepresentation(BsonType.String)]
        Married,
        [BsonRepresentation(BsonType.String)]
        Unmarried,
        [BsonRepresentation(BsonType.String)]
        Divorced
    }

    public enum BloodGroup
    {
        OPositive,
        APositive,
        BPositive,
        ABPositive,
        ONegative,
        ANegative,
        BNegative,
        ABNegative,
        Unknown
    }   
    
    public enum AvailabilityStatus
    {
        InVacation,
        Available
    }


}
