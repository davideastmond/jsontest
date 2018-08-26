using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONTest
{
    public class FamilyMember
    {
        public enum e_familial_relationship
        {
            daughter, son, niece, nephew, cousin, grandfather, grandmother, aunt, uncle,
            mother, father, half_brother, half_sister, brother,
            sister, step_son, step_daughter, granddaughter, grandson, grandniece, grandnephew
        }
        public enum e_blood_relation { in_law, biological, adoptive, na }
        public enum e_lineage { maternal, paternal, na }
        public enum e_generation { none, great, great_great, great_great_great }

        [JsonIgnore]
        public SoapCharacter soap_Character_Role { get; set; }
        public e_familial_relationship FamilialRelationsip { get; set; }
        public e_blood_relation BloodRelation { get; set; }
        public e_lineage Mat_Pat_Lineage { get; set; }
        public e_generation generation { get; set; }

        public FamilyMember(SoapCharacter init_character)
        {
            soap_Character_Role = init_character; // Intial set up
        }
    }
    public class SoapCharacter
    {
        public enum SoapFamily { DiMera, Horton, Brady, Carver, Kiriakis, Black, Evans, Johnson, Deveraux, Larson, Hernandez, Other, Roberts, Reed, Weston }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public List<SoapFamily> FamilyMembership { get; set; }
        private List<FamilyMember> _IndividualFamilyMembers = new List<FamilyMember>();
        public List<FamilyMember> Ind_FamilyMembers
        {
            get
            {
                return _IndividualFamilyMembers;
            }
        }
        public MaritalStatus mStatus { get; private set; }

        SoapCharacter Spouse { get; set; }
        [JsonIgnore]
        public SoapCharacter Father { get; set; }
        [JsonIgnore]
        public SoapCharacter Mother { get; set; }

        public List<SoapCharacter> children { get; set; }
        public bool isAlive { get; set; }

        public SoapCharacter(string fname, string lname)
        {
            this.firstName = fname;
            this.lastName = lname;
            FamilyMembership = new List<SoapFamily>();
            children = new List<SoapCharacter>();
            isAlive = true; // Default
        }

        public void SetMaritalStatus(MaritalStatus _mStatus)
        {
            mStatus = _mStatus;
        }
        public void SetSpouse(SoapCharacter _spouse)
        {
            Spouse = _spouse;
        }
        public void CreateNewFamilyMember(SoapCharacter sc, FamilyMember.e_familial_relationship fr, FamilyMember.e_blood_relation br,
            FamilyMember.e_lineage lin, FamilyMember.e_generation gen)
        {
            FamilyMember newFamilyMember = new FamilyMember(sc);
            newFamilyMember.FamilialRelationsip = fr;
            newFamilyMember.BloodRelation = br;
            newFamilyMember.Mat_Pat_Lineage = lin;
            newFamilyMember.generation = gen;
            this.Ind_FamilyMembers.Add(newFamilyMember);
        }

    }
}
