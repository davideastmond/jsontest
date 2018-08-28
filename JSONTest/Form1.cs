using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

namespace JSONTest
{
    public enum MaritalStatus {  Single, Divorced, Married, Widowed }
    


    public partial class Form1 : Form
    {
        TcpListener mListener = new TcpListener(IPAddress.Any, 545);
        TcpClient mServerClient;
        List<SoapCharacter> masterList = new List<SoapCharacter>();
        const string mrk = "▲";
        public Form1()
        {
            InitializeComponent();
            
           
            SoapCharacter chad_dimera = new SoapCharacter("Chad", "DiMera");
            
            chad_dimera.SetMaritalStatus(MaritalStatus.Married);
            chad_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.DiMera);
               

            SoapCharacter abi_dimera = new SoapCharacter("Abigail", "DiMera");
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Horton);
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.DiMera);
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Johnson);
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Deveraux);
            abi_dimera.SetMaritalStatus(MaritalStatus.Married);
            chad_dimera.SetSpouse(abi_dimera);


            SoapCharacter thomas_dimera = new SoapCharacter("Thomas", "DiMera");
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.DiMera);
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Horton);
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Johnson);
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Deveraux);
            thomas_dimera.SetMaritalStatus(MaritalStatus.Single);

            chad_dimera.children.Add(thomas_dimera);
            abi_dimera.children.Add(thomas_dimera);


            PrepareCast();
        }
        private void PrepareCast()
        {
            SoapCharacter chad_dimera = new SoapCharacter("Chad", "DiMera");
            SoapCharacter abi_dimera = new SoapCharacter("Abigail", "DiMera");
            SoapCharacter thomas_dimera = new SoapCharacter("Thomas", "DiMera");
            SoapCharacter ej_dimera = new SoapCharacter("EJ", "DiMera");
            SoapCharacter kristen_dimera = new SoapCharacter("Kristen", "DiMera");
            SoapCharacter stefano_dimera = new SoapCharacter("Stefano", "DiMera");
            SoapCharacter stefan_o_dimera = new SoapCharacter("Stefan", "DiMera");
            SoapCharacter andre_dimera = new SoapCharacter("Andre", "DiMera");
            SoapCharacter tony_dimera = new SoapCharacter("Tony", "DiMera");

            SoapCharacter vivian_alamaine = new SoapCharacter("Vivian", "Alamain");

            SoapCharacter jack_deveraux = new SoapCharacter("Jack", "Deveraux");
            SoapCharacter laura_horton = new SoapCharacter("Laura", "Horton");
            SoapCharacter bill_horton = new SoapCharacter("Bill", "Horton");
            SoapCharacter madeline_woods = new SoapCharacter("Madeline Peterson", "Woods");
            SoapCharacter jennifer_horton = new SoapCharacter("Jennifer Rose", "Deveraux");
            SoapCharacter jj_deveraux = new SoapCharacter("Jack Junior", "Deveraux");

            SoapCharacter alice_horton = new SoapCharacter("Alice", "Horton");
            SoapCharacter tom_horton = new SoapCharacter("Tom", "Horton");

            SoapCharacter steve_johnson = new SoapCharacter("Steve", "Johnson");
            SoapCharacter kayla_johnson = new SoapCharacter("Kayla", "johnson");

            SoapCharacter joey_johnson = new SoapCharacter("Joey", "Johnson");
            SoapCharacter stephanie_johnson = new SoapCharacter("Stephanie", "Johnson");
            SoapCharacter trip_johnson = new SoapCharacter("Trip", "Dalton");

            SoapCharacter adrienne_johnson = new SoapCharacter("Adrienne", "Johnson");
            SoapCharacter jackson_sonny_kiriakis = new SoapCharacter("Jackson 'Sonny'", "Kiriakis");
            SoapCharacter justin_kiriakis = new SoapCharacter("Justin", "Kiriakis");
            SoapCharacter maggie_kiriakis = new SoapCharacter("Maggie", "Kiriakis");
            SoapCharacter victor_kiriakis = new SoapCharacter("Victor", "Kiriakis");

            SoapCharacter brady_black = new SoapCharacter("Brady", "Black");

            SoapCharacter tate_black = new SoapCharacter("Tate", "Black");
            SoapCharacter teresa_donovan = new SoapCharacter("Teresa", "Donovan");

            SoapCharacter lucas_horton = new SoapCharacter("Lucas", "Horton");
            SoapCharacter will_horton = new SoapCharacter("William", "Horton");
            SoapCharacter ariana_grace_horton = new SoapCharacter("Ariana", "Horton");

            SoapCharacter abraham_carver = new SoapCharacter("Abraham", "Carver");
            SoapCharacter alexandra_carver = new SoapCharacter("Lexie", "Carver");
            SoapCharacter theo_carver = new SoapCharacter("Theo", "Carver");
            SoapCharacter celeste_perrault = new SoapCharacter("Celeste", "Perrault");

            SoapCharacter kate_dimera = new SoapCharacter("Kate", "DiMera");
            SoapCharacter austin_reed = new SoapCharacter("Austin", "Reed");
            SoapCharacter carrie_reed = new SoapCharacter("Carrie", "Reed");
            SoapCharacter billie_reed = new SoapCharacter("Billie", "Reed");

            SoapCharacter roman_brady = new SoapCharacter("Roman", "Brady");
            SoapCharacter bo_brady = new SoapCharacter("Bo", "Brady");
            SoapCharacter eric_brady = new SoapCharacter("Eric", "Brady");
            SoapCharacter caroline_brady = new SoapCharacter("Caroline", "Brady");
            SoapCharacter belle_brady = new SoapCharacter("Belle", "Brady");

            SoapCharacter claire_brady = new SoapCharacter("Claire", "Brady");
            SoapCharacter hope_williams_brady = new SoapCharacter("Hope Williams", "Brady");
            SoapCharacter ciara_brady = new SoapCharacter("Ciara", "Brady");
            SoapCharacter shawn_brady = new SoapCharacter("Shawn", "Brady");
            SoapCharacter shawn_douglas_brady = new SoapCharacter("Shawn Douglas", "Brady");
            SoapCharacter chelsea_brady = new SoapCharacter("Chelsea", "Brady");

            SoapCharacter kimberly_donovan = new SoapCharacter("Kimberly", "Donovan");
            SoapCharacter samantha_dimera = new SoapCharacter("Samantha", "DiMera");
            
            SoapCharacter marlena_evans = new SoapCharacter("Marlena", "Evans");
            SoapCharacter john_black = new SoapCharacter("John", "Black");
            SoapCharacter paul_narita = new SoapCharacter("Paul", "Narita");

            SoapCharacter isabella_toscano = new SoapCharacter("Isabella", "Toscano");

            SoapCharacter rafe_hernandez = new SoapCharacter("Rafe", "Hernandez");
            SoapCharacter gabriella_hernandez = new SoapCharacter("Gabriella", "Hernandez");
            SoapCharacter end_tag = new SoapCharacter("end", "tag");

            isabella_toscano.isAlive = false;
            andre_dimera.isAlive = false;
            jack_deveraux.isAlive = false;
            stefano_dimera.isAlive = false;
            tony_dimera.isAlive = false;

            // Andre's family
            andre_dimera.SetSpouse(kate_dimera);
            andre_dimera.CreateNewFamilyMember(chad_dimera, FamilyMember.e_familial_relationship.half_brother, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);
            andre_dimera.CreateNewFamilyMember(alexandra_carver, FamilyMember.e_familial_relationship.half_sister, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);
            andre_dimera.CreateNewFamilyMember(ej_dimera, FamilyMember.e_familial_relationship.half_brother, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);
            andre_dimera.CreateNewFamilyMember(tony_dimera, FamilyMember.e_familial_relationship.half_brother, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);

            // Kate's info
            kate_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.DiMera);
            kate_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Reed);
            kate_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Roberts);
            kate_dimera.children.Add(lucas_horton);
            kate_dimera.children.Add(austin_reed);
            kate_dimera.children.Add(billie_reed);
            kate_dimera.SetMaritalStatus(MaritalStatus.Widowed);
            kate_dimera.CreateNewFamilyMember(will_horton, FamilyMember.e_familial_relationship.grandson, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);

            // Chad's Family Membership
            chad_dimera.SetMaritalStatus(MaritalStatus.Married);
           
            chad_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.DiMera);
            chad_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Other);

            // Chad's parents
            chad_dimera.Father = stefano_dimera;
            chad_dimera.Mother = madeline_woods;
            chad_dimera.SetSpouse(abi_dimera);
            chad_dimera.children.Add(thomas_dimera);
            chad_dimera.CreateNewFamilyMember(kristen_dimera, FamilyMember.e_familial_relationship.sister, FamilyMember.e_blood_relation.adoptive, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            

            // Chad's Familials
            chad_dimera.CreateNewFamilyMember(jennifer_horton, FamilyMember.e_familial_relationship.mother, 
                FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            chad_dimera.CreateNewFamilyMember(jack_deveraux, FamilyMember.e_familial_relationship.father, FamilyMember.e_blood_relation.in_law
                , FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            chad_dimera.CreateNewFamilyMember(jj_deveraux, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.in_law
                , FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            chad_dimera.CreateNewFamilyMember(theo_carver, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);
            chad_dimera.CreateNewFamilyMember(alexandra_carver, FamilyMember.e_familial_relationship.half_sister, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);

            // Carvers
            // Lexie
            
            // Jennifer Horton
            jennifer_horton.children.Add(jj_deveraux);
            jennifer_horton.children.Add(abi_dimera);
            jennifer_horton.CreateNewFamilyMember(thomas_dimera, FamilyMember.e_familial_relationship.grandson, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jennifer_horton.CreateNewFamilyMember(steve_johnson, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jennifer_horton.CreateNewFamilyMember(chad_dimera, FamilyMember.e_familial_relationship.son, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jennifer_horton.CreateNewFamilyMember(lucas_horton, FamilyMember.e_familial_relationship.half_brother, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jennifer_horton.CreateNewFamilyMember(will_horton, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);

            jennifer_horton.Mother = laura_horton;
            jennifer_horton.Father = bill_horton;

            // Abigail's Family Membership
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Horton);
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.DiMera);
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Johnson);
            abi_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Deveraux);
            abi_dimera.SetMaritalStatus(MaritalStatus.Married);
           
            // Abigail DiMera's Parents
            abi_dimera.Mother = jennifer_horton;
            abi_dimera.Father = jack_deveraux;

            // Abigail's familials
            abi_dimera.CreateNewFamilyMember(tom_horton, FamilyMember.e_familial_relationship.grandfather, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.maternal, FamilyMember.e_generation.none);
            abi_dimera.CreateNewFamilyMember(jj_deveraux, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.biological,
                FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            abi_dimera.CreateNewFamilyMember(steve_johnson, FamilyMember.e_familial_relationship.uncle, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);

            // Steve Johson's children
            steve_johnson.children.Add(trip_johnson);
            steve_johnson.children.Add(stephanie_johnson);
            stephanie_johnson.children.Add(joey_johnson);

            // Adrienne Johnson
            adrienne_johnson.SetMaritalStatus(MaritalStatus.Divorced);
            

            // Steve's family
            steve_johnson.CreateNewFamilyMember(abi_dimera, FamilyMember.e_familial_relationship.niece, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);
            steve_johnson.CreateNewFamilyMember(chad_dimera, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            steve_johnson.SetSpouse(kayla_johnson);
            steve_johnson.CreateNewFamilyMember(jack_deveraux, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.biological
                , FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            steve_johnson.CreateNewFamilyMember(jennifer_horton, FamilyMember.e_familial_relationship.sister, FamilyMember.e_blood_relation.in_law
                , FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            steve_johnson.CreateNewFamilyMember(jj_deveraux, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.paternal
                , FamilyMember.e_generation.none);
            steve_johnson.CreateNewFamilyMember(thomas_dimera, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.great);
            steve_johnson.CreateNewFamilyMember(jackson_sonny_kiriakis, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological
                , FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            steve_johnson.CreateNewFamilyMember(justin_kiriakis, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);

            // JJ Deveraux parents
            jj_deveraux.Mother = jennifer_horton;
            jj_deveraux.Father = jack_deveraux;

            // JJ_deveraux familials
            jj_deveraux.CreateNewFamilyMember(abi_dimera, FamilyMember.e_familial_relationship.sister, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jj_deveraux.CreateNewFamilyMember(thomas_dimera, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jj_deveraux.CreateNewFamilyMember(chad_dimera, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jj_deveraux.CreateNewFamilyMember(lucas_horton, FamilyMember.e_familial_relationship.uncle, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.maternal
                , FamilyMember.e_generation.none);
       


            kayla_johnson.SetSpouse(steve_johnson);

            // Steve's family lineage
            steve_johnson.FamilyMembership.Add(SoapCharacter.SoapFamily.Johnson);
            steve_johnson.FamilyMembership.Add(SoapCharacter.SoapFamily.Deveraux);

            // Kayla's family lineage
            kayla_johnson.FamilyMembership.Add(SoapCharacter.SoapFamily.Brady);
            kayla_johnson.FamilyMembership.Add(SoapCharacter.SoapFamily.Johnson);
            kayla_johnson.FamilyMembership.Add(SoapCharacter.SoapFamily.Deveraux);

            kayla_johnson.Mother = caroline_brady;
            kayla_johnson.Father = shawn_brady;
            // Kayla's children
            kayla_johnson.children.Add(stephanie_johnson);
            kayla_johnson.children.Add(joey_johnson);
            kayla_johnson.children.Add(trip_johnson);

            kayla_johnson.CreateNewFamilyMember(trip_johnson, FamilyMember.e_familial_relationship.step_son, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
         


            // Thomas DiMera
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.DiMera);
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Horton);
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Johnson);
            thomas_dimera.FamilyMembership.Add(SoapCharacter.SoapFamily.Deveraux);
            thomas_dimera.SetMaritalStatus(MaritalStatus.Single);
            thomas_dimera.Father = chad_dimera;
            thomas_dimera.Mother = abi_dimera;
                 

            chad_dimera.children.Add(thomas_dimera);
            abi_dimera.children.Add(thomas_dimera);

            // Brady Black
            brady_black.FamilyMembership.Add(SoapCharacter.SoapFamily.Kiriakis);
            brady_black.FamilyMembership.Add(SoapCharacter.SoapFamily.Black);
            brady_black.Father = john_black;
            brady_black.Mother = isabella_toscano;
            brady_black.CreateNewFamilyMember(paul_narita, FamilyMember.e_familial_relationship.half_brother, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);

            // Marlena
            marlena_evans.FamilyMembership.Add(SoapCharacter.SoapFamily.Evans);
            marlena_evans.FamilyMembership.Add(SoapCharacter.SoapFamily.Black);
            marlena_evans.FamilyMembership.Add(SoapCharacter.SoapFamily.Brady);
            marlena_evans.SetMaritalStatus(MaritalStatus.Divorced);
            marlena_evans.children.Add(eric_brady);
            marlena_evans.children.Add(samantha_dimera);
            marlena_evans.children.Add(belle_brady);
            marlena_evans.CreateNewFamilyMember(shawn_douglas_brady, FamilyMember.e_familial_relationship.son, FamilyMember.e_blood_relation.in_law
                , FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            marlena_evans.CreateNewFamilyMember(claire_brady, FamilyMember.e_familial_relationship.granddaughter, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            marlena_evans.CreateNewFamilyMember(brady_black, FamilyMember.e_familial_relationship.step_son, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            marlena_evans.CreateNewFamilyMember(will_horton, FamilyMember.e_familial_relationship.grandson, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);

            // Jack Deveraux
            jack_deveraux.SetMaritalStatus(MaritalStatus.Widowed);
            jack_deveraux.children.Add(jj_deveraux);
            jack_deveraux.children.Add(abi_dimera);
            jack_deveraux.FamilyMembership.Add(SoapCharacter.SoapFamily.Deveraux);
            jack_deveraux.FamilyMembership.Add(SoapCharacter.SoapFamily.Johnson);

            // Jack's family
            jack_deveraux.CreateNewFamilyMember(chad_dimera, FamilyMember.e_familial_relationship.son, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(thomas_dimera, FamilyMember.e_familial_relationship.grandson, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(steve_johnson, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na,
                 FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(adrienne_johnson, FamilyMember.e_familial_relationship.sister, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(jackson_sonny_kiriakis, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na,
                 FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(kayla_johnson, FamilyMember.e_familial_relationship.sister, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na
                , FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(stephanie_johnson, FamilyMember.e_familial_relationship.niece, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na
                ,
                 FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(trip_johnson, FamilyMember.e_familial_relationship.nephew, FamilyMember.e_blood_relation.biological, FamilyMember.e_lineage.na, FamilyMember.e_generation.none);
            jack_deveraux.CreateNewFamilyMember(lucas_horton, FamilyMember.e_familial_relationship.brother, FamilyMember.e_blood_relation.in_law, FamilyMember.e_lineage.na, FamilyMember.e_generation.none);


            masterList.Add(chad_dimera); masterList.Add(abi_dimera); masterList.Add(thomas_dimera);
            masterList.Add(steve_johnson); masterList.Add(stephanie_johnson); masterList.Add(kayla_johnson); masterList.Add(alice_horton);
            masterList.Add(tom_horton); masterList.Add(jj_deveraux);
            masterList.Add(joey_johnson); masterList.Add(stefano_dimera); masterList.Add(madeline_woods);
            masterList.Add(jennifer_horton); masterList.Add(laura_horton); masterList.Add(tom_horton);
            masterList.Add(trip_johnson); masterList.Add(jackson_sonny_kiriakis); masterList.Add(will_horton); masterList.Add(maggie_kiriakis);
            masterList.Add(adrienne_johnson); masterList.Add(justin_kiriakis); masterList.Add(marlena_evans); masterList.Add(roman_brady);
            masterList.Add(brady_black); masterList.Add(tate_black); masterList.Add(teresa_donovan); masterList.Add(kristen_dimera);
            masterList.Add(john_black); masterList.Add(victor_kiriakis); masterList.Add(paul_narita); masterList.Add(marlena_evans);
            masterList.Add(claire_brady); masterList.Add(shawn_douglas_brady); masterList.Add(isabella_toscano); masterList.Add(rafe_hernandez); masterList.Add(gabriella_hernandez);
            masterList.Add(samantha_dimera); masterList.Add(chelsea_brady); masterList.Add(abraham_carver); masterList.Add(theo_carver); masterList.Add(alexandra_carver);
            masterList.Add(celeste_perrault); masterList.Add(end_tag); masterList.Add(andre_dimera); masterList.Add(tony_dimera); 
            
        }
        private void ListenerTask()
        {
            // For listening
            mListener.Start();
            mServerClient = mListener.AcceptTcpClient();
            Console.WriteLine("Connection Established.");

            // get JSON info
            string outputJSON = JsonConvert.SerializeObject(masterList);
          
            byte[] binaryJSON = Encoding.ASCII.GetBytes(outputJSON);
            Console.WriteLine("JSON length is {0} bytes ", binaryJSON.Length);
            Console.WriteLine("Sending bytes over w/ marker point");
            NetworkStream str = mServerClient.GetStream();

            // str.Write(JL, 0, JL.Length); // send the JSon length - should be three bytes
            // str.Write(marker, 0, marker.Length);
            byte[] jsonLength = BitConverter.GetBytes(binaryJSON.Length);

            if (jsonLength.Length > 9)
            {
                throw new Exception("Byte header is too large. Must be 1-9");
            }

            string finalTagLength = jsonLength.Length.ToString(); // This is to be tagged onto the 8 byte header
            string byteHeader = "%&$#_*&" + finalTagLength;

            byte[] sendByteHeader = Encoding.ASCII.GetBytes(byteHeader);
            str.Write(sendByteHeader, 0, sendByteHeader.Length);
            str.Write(jsonLength, 0, jsonLength.Length);
            // Next send the binary JSON
            str.Write(binaryJSON, 0, binaryJSON.Length);
        }

        private void startserver_click(object sender, EventArgs e)
        {
            Thread listenerThread = new Thread(() => ListenerTask());
            Console.WriteLine("Listening thread started..");
            listenerThread.Start();
        }
    }
}
