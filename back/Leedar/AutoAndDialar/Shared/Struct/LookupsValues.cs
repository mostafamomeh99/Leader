using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Struct
{
    public struct Settings
    {
        public static Guid DefultGUID => Guid.Parse("a5e4c335-304a-4c21-9996-9f74752ce2ec");
        public static DateTime EntityCreateionDateTime => new DateTime(2021, 9, 10);
    }
    public struct StaticUser
    {
        public static Guid System => new("3abfa071-e941-48e6-a492-b6cad5debf61");
        public static Guid POMApplicationUser => new("d741da85-bd74-42cc-8d22-8176f49580e6");
        public static Guid DefultSupperAdmin => new("d06d5759-1e13-4074-966a-d6ed625815f0");
        public static Guid DefultAdmin => new("f5929f3e-8f81-43b1-b074-5cb01e664e02");
        public static Guid DefultAdmin1 => new("f5929ffe-8f8b-e3b1-b074-5cb01e664e02");
        public static Guid DefultAdmin2 => new("fe929f3e-8fa1-43b1-b074-5cb01e664e02");

        public static Guid DefultEmployee => new("032545b3-35dc-4411-938a-10ce473680fb");
    }
    public struct Roles
    {
        public static Guid System => new("b57d5da1-98e7-4c98-ac00-104919cb8e8d");
        public static Guid SuperAdmin => new("24e65b31-a815-4fb0-a5fa-4b78aab03c72");
        public static Guid Admin => new("5918287c-140d-4938-a8ee-d3a3099ec957");
        public static Guid Supervisor => new("93b91e52-5850-4190-9e87-2a1bfbd81910");
        public static Guid Leader => new("6fdd3e8a-ebfc-4fe5-8a48-ed2bde9fb2ad");
        public static Guid Reporter => new("746f79ee-bc4a-4e58-95d2-01c73cf3a868");
        public static Guid Employee => new("ad0b3b57-295f-4312-bba1-b09a11865237");
        public static Guid QualityEmployee => new("8eef00df-f0c7-44e8-886d-3c114e5206cc");
        public static Guid QualitySupervisor => new("0bf26480-4289-4b01-8484-abfaabb284bb");
        public static Guid ContactSupport => new("12346480-4289-4b01-8484-abfaabb284bb");
        public static Guid ContactSupportSupervisor => new("45676480-4289-4b01-8484-abfaabb284bb");
        public static Guid Dashboard => new("11276480-4289-4b01-8484-abfaabb284bb");

    }
    public struct RolesName
    {
        public static string System = "System";
        public static string SuperAdmin = "SuperAdmin";
        public static string Admin = "Admin";
        public static string Supervisor = "Supervisor";
        public static string Leader = "Leader";
        public static string Reporter = "Reporter";
        public static string Employee = "Employee";
    }

    public struct EntityActionType
    {
        public static Guid ScheduleNewCall => new("090e1ae7-3878-489a-ab85-8c9affb4a913");
        public static Guid SaveCallInSuccessStatus => new("0280d3e4-0b91-4a09-af6c-9493365722e9");
        public static Guid SaveCallInNotSuccessStatus => new("d8ee0ba8-5f2a-4691-a388-8616dbdf39ba");
        public static Guid SaveCallInRecallStatus => new("63a13eb8-3949-42d1-a92a-aa3e93867f79");
        public static Guid NotifyOnBillCreated => new("12121212-1212-42d1-a92a-aa3e93867f79");
        public static Guid ScheduleNewCallToBankAgent => new("2e0f37f8-68c3-4e0e-bcbd-61ca7a7e403a");
        public static Guid ScheduleNewCallToReasonAgent => new("48764236-2d9b-4f60-9eb0-3f3193c9bf3c");
        public static Guid SaveCallInNewSubStatus => new("740446f8-835c-4e70-9b35-2549b3e17556");
        public static Guid ScheduleFollowingCallToBankAgent => new("21459cac-455d-4b06-b4d3-25af404389e5");
    }
    public struct EntityFieldActionType
    {
        public static Guid ExecuteDynamicFunction => new("1f4398fe-7940-4310-8149-40f71b5bb97b");
    }


    public struct CallStatus
    {
        public static Guid QueuedInSystem => new("0c027c7d-59a2-4319-a876-b22015611f97");
        public static Guid QueuedInDialer => new("9d7064b9-a41a-4b76-9889-d26750f3eca6");
        public static Guid ScheduledInSystem => new("d252adcd-cb7c-45bb-a1f7-d7905a14e348");
        public static Guid ScheduledInDialer => new("29dc61d3-de6b-4385-bb40-0ce35ecb4625");
        public static Guid NotSuccessByDialer => new("123c61d3-de6b-4385-bb40-0ce35ecb4625");

        public static Guid Assigned => new("75bad3f5-23cb-47e7-8485-a83e14e325d3");

        public static Guid Recall => new("2cd4cc0e-afbd-4a72-b930-8911662a4fcf");
        public static Guid Success => new("b8151e6f-6415-4b46-9b74-5dae2e47d072");
        public static Guid Notsuccess => new("df1523df-5fc3-41fc-a2d0-b3937ca4228f");
        public static Guid Completed => new("beb45b24-dd0c-40a6-8eb3-c15c38742fc3");

    }
    public struct CallStatusString
    {
        public const string QueuedInSystem = "0c027c7d-59a2-4319-a876-b22015611f97";
        public const string QueuedInDialer = "9d7064b9-a41a-4b76-9889-d26750f3eca6";
        public const string ScheduledInSystem = "d252adcd-cb7c-45bb-a1f7-d7905a14e348";
        public const string ScheduledInDialer = "29dc61d3-de6b-4385-bb40-0ce35ecb4625";
        public const string Assigned = "75bad3f5-23cb-47e7-8485-a83e14e325d3";

        public const string Recall = "2cd4cc0e-afbd-4a72-b930-8911662a4fcf";
        public const string Success = "b8151e6f-6415-4b46-9b74-5dae2e47d072";
        public const string Notsuccess = "df1523df-5fc3-41fc-a2d0-b3937ca4228f";

    }
    public struct CallType
    {
        public static Guid Normal => new("3ac144c5-5ea4-4ca3-a8a3-0b2f173dd6db");
        public static Guid Auto => new("b22c1515-23d2-452b-82f5-5f2999582f8d");
        public static Guid CollectingCallFollowup => new("331c1515-23d2-452b-82f5-5f2999582f8d");
    }
    public struct SubStatus
    {
        public static Guid Interested => new("e8934a71-8d9e-4835-a9ef-5df34b7e4d15");
        public static Guid NotInterested => new("4922e764-6ff0-4159-88a2-26fa12a114fc");
        public static Guid InProgress => new("f3d6aefc-2dcc-46a1-a66b-b052f7e759d3");
    }
    public struct Category
    {

        public static Guid ExemptionApplicant => new("dc85f064-c886-4052-916e-ae76002ebf78");
        public static Guid CollectingCall => new("a37fd20b-2e0a-4732-9136-ade00039a977");
    }
    public struct Campaign
    {

        public static Guid August_collect => new("bf09f692-f8a3-4c4e-b7e6-aee4002ef467");

    }
    public struct ConditionFor
    {
        public static Guid Show => new("32ce529a-107e-4242-bd48-00d87d85e68c");
        public static Guid Disabled => new("5e6a7ddf-d4a2-49d8-81b1-195bc9eb63b6");
        public static Guid ReadOnly => new("df704671-910c-4625-8ce7-577aa2ca95ad");
        public static Guid Selected => new("b1d9a26b-745a-4a5e-bfb7-b3519a7c0e47");
        public static Guid Required => new("8ce24129-c34f-4ed2-94ae-1a8d8fb81182");
        public static Guid Execute => new("ce8d37c5-66c8-41e9-ade0-cb8d6d13ffa9");
    }
    public struct ConditionType
    {
        public static Guid Equal => new("7cbdb20f-8790-4193-8bca-4adb1ea743a9");
        public static Guid NotEqual => new("df540314-dfa9-4a2d-bc82-863bbb77b271");
        public static Guid NotNull => new("0f979f1c-4419-420e-81d2-0ce99048049f");
        public static Guid Null => new("47d75e03-d7a1-467f-a870-5cf451b552a6");
        public static Guid Contain => new("059f4279-53da-4d31-bac3-cf75092b9e44");
        public static Guid LessThan => new("b47b64a4-da48-4d66-9972-532c8f23eec3");
        public static Guid LessThanOrEqual => new("f29b0cea-10f5-4a62-90e2-6377f644b2a3");
        public static Guid MoreThan => new("c03cfa6a-8125-458b-85dc-babc046417bf");
        public static Guid MoreThanOrEqual => new("55899e39-2eb5-42c4-a090-f719457b865f");
        public static Guid In => new("45fa4a17-8a36-4a2b-a5fb-c389f65c6bf9");
    }
    public struct ContractStatus
    {
        public static Guid Valid => new("33569bb0-be6c-4365-9d61-c949d898afb3");
        public static Guid ValidWithSuspensionOfPayments => new("89e12a91-6802-4460-a15c-83ac918673c9");
    }
    public struct ContractType
    {
        public static Guid InvestmentLoan => new("e4f6dcaf-162f-4f44-82a7-1a8824ef8c83");
        public static Guid PrivateLoan => new("036e5f44-4255-4d2b-99ae-11ca89770ec2");
        public static Guid ReadyHousing => new("70411403-bb96-4673-beb8-e87fe90ce141");
    }
    public struct EmployerSector
    {
        public static Guid Special => new("fb52e85a-7635-4091-b49a-7823982c99fa");
        public static Guid Soldier => new("370d9a91-9cee-4e71-bd21-421b21403db8");
        public static Guid Civil => new("0649ea63-7ad7-4041-83b3-7951dedbb385");
        public static Guid Undefined => new("5db2ffc4-ce35-4e46-8e62-bf5f5f8c2cdc");

    }
    public struct EmployerType
    {
        public static Guid InsuranceRetirement => new("fabd74f6-40c4-484a-888e-f367c1103a57");
        public static Guid Governmental => new("5fbb2a81-8d63-419f-92c9-31970a68e8cd");
        public static Guid Special => new("b9f3fc26-f1dc-4460-a7e2-c96c628d58fc");
        public static Guid Student => new("5e7675b1-82f5-465a-ab40-90d50016d9ee");
        public static Guid Soldier => new("3ef778b6-7513-4e3b-9114-cec109e6c02d");
        public static Guid Incitant => new("6461ec15-3e6c-4f60-b6b8-3c0b337096ba");
        public static Guid Retired => new("3055a86b-6f82-4515-83b0-58cc16672f03");
        public static Guid Civil => new("3ea30155-5944-41fd-a2cb-11a804f3755e");
        public static Guid Other => new("b85336c3-03db-458e-bc9c-f06951501330");
    }
    public struct FieldType
    {
        public static Guid Button => new("92a1f535-6c86-4489-a494-afcd1165334a");
        public static Guid CheckBox => new("66326b14-7fa5-45f4-b3df-92f364b146d8");
        public static Guid CheckBoxGroup => new("0caa25d9-befb-4096-9041-c05e7b4da188");
        public static Guid DateTime => new("d4730e56-dcc3-42e8-af4a-a6b66edbb728");
        public static Guid Date => new("f9e4efb5-f7c4-44d5-9c35-febfbfc7f834");
        public static Guid Time => new("24a3e2ce-c8d2-485d-9bfb-028ad5ae5444");
        public static Guid SDateTime => new("2bcfff4a-8236-486e-9691-da019d679600");

        public static Guid Number => new("2bccee4a-8236-486e-9691-da019d679600");
        public static Guid Text => new("bc557ce6-adb6-4a98-9214-639534862014");
        public static Guid TextArea => new("61e80126-233e-4143-94bc-e906c1e64b03");
        public static Guid OneSelect => new("d448dd89-168e-47eb-9425-36a4074cd853");
        public static Guid MultibelSelect => new("9eaed8a2-517b-48c8-bfb8-eb2344a79804");
        public static Guid RadioButton => new("fb14e732-8d25-4ffb-bd63-b5e6e09cf231");
        public static Guid Label => new("45de289b-67b3-406f-aa95-b01a857fdf74");
        public static Guid ViewList => new("b040939f-d7eb-47cc-9a5a-f063db7fdd8e");
        public static Guid File => new("061beaca-01b1-443a-a5f9-bd636b8ee9b1");
    }


    public struct FieldTypeString
    {
        public const string Button = "92a1f535-6c86-4489-a494-afcd1165334a";
        public const string CheckBox = "66326b14-7fa5-45f4-b3df-92f364b146d8";
        public const string CheckBoxGroup = "0caa25d9-befb-4096-9041-c05e7b4da188";
        public const string DateTime = "d4730e56-dcc3-42e8-af4a-a6b66edbb728";
        public const string Date = "f9e4efb5-f7c4-44d5-9c35-febfbfc7f834";
        public const string Time = "24a3e2ce-c8d2-485d-9bfb-028ad5ae5444";

        public const string SDateTime = "2bcfff4a-8236-486e-9691-da019d679600";

        public const string Number = "2bccee4a-8236-486e-9691-da019d679600";
        public const string Text = "bc557ce6-adb6-4a98-9214-639534862014";
        public const string TextArea = "61e80126-233e-4143-94bc-e906c1e64b03";
        public const string OneSelect = "d448dd89-168e-47eb-9425-36a4074cd853";
        public const string MultibelSelect = "9eaed8a2-517b-48c8-bfb8-eb2344a79804";
        public const string RadioButton = "fb14e732-8d25-4ffb-bd63-b5e6e09cf231";
        public const string Label = "45de289b-67b3-406f-aa95-b01a857fdf74";
        public const string ViewList = "b040939f-d7eb-47cc-9a5a-f063db7fdd8e";
        public const string File = "061beaca-01b1-443a-a5f9-bd636b8ee9b1";
    }
    public struct Gender
    {
        public static Guid Male => new("44c98a44-0ca9-4414-9d7e-36c4a4227faa");
        public static Guid Female => new("10a329bf-ddfb-4bcb-a33c-7fca1ec401fc");
    }
    public struct InsuranceStatus
    {
        public static Guid NotAffiliated => new("bf7c1ad9-d640-42ce-abc8-65916cb65ff5");
        public static Guid Affiliated => new("f4f4fd7d-74ce-4a6d-b289-9e8f338428ec");
    }
    public struct LoanTimeStatus
    {
        public static Guid TimeIsDone => new("c2055681-b561-4bf0-ad8c-52ba5b3b9d03");
        public static Guid TimeIsNotDone => new("0146d887-1f2d-4555-b98a-bfa3a46e11e5");
    }
    public struct PaymentGateway
    {
        public static Guid RetirementAgreement => new("79eb70b5-8e13-453a-b711-0eb9bae97c95");
        public static Guid SustainableThroughTheBank => new("c078abe9-04a7-4b7b-a82b-9f9aa92187f0");
        public static Guid BranchReview => new("e51a86c8-e417-4e01-8fef-c291feebcaa7");
        public static Guid PersonalPayment => new("d4eba6ed-a6f5-4f37-afa1-1ddb0e71ac84");
        public static Guid EstablishmentPublicPension => new("e3be17ef-0288-46cc-9ee9-23a3b129a36a");
        public static Guid FullLoan => new("f4c6af4c-ba6e-4295-99af-61a7f3383518");
        public static Guid ExpeditedInstallment => new("d44871a1-e0d0-4696-bb5e-7cfbda576620");
        public static Guid SADADATM => new("2776d3cb-3478-47e2-850a-3f7254e72325");
    }
    public struct PaymentMethod
    {
        public static Guid LatePayment => new("e638f6e0-9b33-49fb-a793-471e0e2348c8");
        public static Guid ExpeditedInstallment => new("d1f18760-ddd2-463c-9bc7-7a5307bdb1ec");
        public static Guid FullLoan => new("7efd8078-a54e-4604-9b9c-ba12f4974470");
        public static Guid ImmediatelyPayment => new("adabb370-7ce7-47af-9548-80c3c2596609");
    }
    public struct Permission
    {
        public static Guid GetContactByIdentity => new("fa0932e7-01c4-4998-b4e5-c50b7bb1ddd1");
        public static Guid CanViewTeamCall => new("4e8468a9-8618-41b0-82cd-48a96aa24f77");
        public static Guid CanViewContactList => new("e814a00e-dc72-4fec-98d4-b4f1406320a0");
        public static Guid CanViewReportDetails => new("e7ba2e81-e26b-4450-b6a1-918be10c5d29");
        public static Guid CanViewReportStatistics => new("be90cb78-4aef-46c8-b309-7cf0451ca094");
        public static Guid CanViewUserList => new("cff4d642-249a-4c4d-b45b-2169ef2be7ab");
        public static Guid CanViewTeamList => new("50723db5-d871-48fa-a401-9b98360e854a");

        public static Guid CanReciveNewCall => new("db18f5f3-8732-41bc-b42f-1924ebe285f4");
        public static Guid CanCreateNewCall => new("c02cab25-67d7-4be2-9527-b7d472edbc7f");
        public static Guid CanCreateCallComment => new("ce07076f-6725-45b0-b679-34459dde58c0");
        public static Guid CanCreateNewContact => new("72091b9c-47ad-44c9-84cc-b628ef8e8296");
        public static Guid CanCreateNewUser => new("16e46a2f-5b9f-405f-935d-7396a1ec76f6");
        public static Guid CanCreateNewTeam => new("8d02afdc-b545-4247-8659-42990e942c3b");

        public static Guid CanUpdateCallInfo => new("4614e0d7-c09b-49c1-b85b-0f500255f2c5");
        public static Guid CanUpdateContactInfo => new("ce9720e2-bcf3-4e73-a998-24c6c87ce85c");
        public static Guid CanUpdateUserInfo => new("a97fb6de-1d8e-4ab7-803c-62d5593bd980");
        public static Guid CanUpdateTeamInfo => new("e7370a6a-ca23-4250-8a3b-68cc4b61d4bf");

        public static Guid CanDisableContact => new("469ba6df-be0a-439d-968e-0a8e929955f2");
        public static Guid CanDisableUser => new("45449f18-1822-40eb-89fd-68b4cb2b5387");
        public static Guid CanDisableTeam => new("d927e0ab-1f79-4135-9ff9-13fe3450eb28");


        public static Guid CanExportCalls => new("fe953828-e3fe-43b7-8b75-e7832bc098be");
        public static Guid CanExportContacts => new("8abe470c-feef-4599-b86b-90963a6ee2fc");
        public static Guid CanExportReports => new("7b604e8c-2c75-427d-b69a-63bdb9840b2f");
        public static Guid CanExportStatistics => new("c7d41074-5d90-469f-8d91-71bc64c7a460");
        public static Guid CanExportTeams => new("7a52d989-3f8a-400d-86c7-2f39b2743845");
        public static Guid CanExportUsers => new("5fa107c5-c308-40e7-a462-4d31665b1f83");
    }
    public struct Priority
    {
        public static Guid VerySpecial => new("5f2c90ee-4842-4797-8da8-c3dffb331609");
        public static Guid Special => new("5f2ca633-4842-4797-8da8-c3dffb331609");
        public static Guid VeryImportant => new("5f2c9033-4842-4797-8da8-c3dffb331609");
        public static Guid Important => new("b44b633e-a94a-4dac-a093-5650aa8184eb");
        public static Guid Normal => new("6aeb7f2a-5a60-4086-8320-55120317806e");
        public static Guid Low => new("64cd40dd-747a-46c7-a91d-123febad6d44");
        public static Guid VeryLow => new("71bd4bae-361c-41a9-bd54-22c29eea602a");
    }
    public struct Survey
    {
        public static Guid Survey1 => new("5f2c9033-4842-4797-8da8-c3dffb331609");
        public static Guid Survey2 => new("b44b633e-a94a-4dac-a093-5650aa8184eb");
        //public static Guid Normal => new("6aeb7f2a-5a60-4086-8320-55120317806e");
        //public static Guid Low => new("64cd40dd-747a-46c7-a91d-123febad6d44");
        //public static Guid VeryLow => new("71bd4bae-361c-41a9-bd54-22c29eea602a");
    }
    public struct QualityTemplateCriteriaType
    {
        public static Guid TenMarks => new("76885fdc-afc0-4840-9d0d-4417f4fabaa8");
        public static Guid MultipleChoice => new("3c8dc9e3-9f9b-43c6-970d-b689349dbe50");
        public static Guid OneChoice => new("9781b43a-ae04-4de8-a6e1-075696a060d0");
        public static Guid WritableMark => new("5a297635-bc35-4bfd-838c-495d60d8b8cc");
    }
    public struct RegistrationType
    {
        public static Guid Application => new("8DEA7D0E-7410-41B1-8A2E-ACEB00ECDCF1");
        public static Guid Domain => new("CAEFD0E1-B868-4D04-AC79-ACEB00ECDCF1");
    }
    public struct RetirementStatus
    {
        public static Guid NotAffiliated => new("bf7c1ad9-d640-42ce-abc8-65916cb65ff5");
        public static Guid Affiliated => new("f4f4fd7d-74ce-4a6d-b289-9e8f338428ec");
    }
    public struct Satisfaction
    {
        public static Guid VerySatisfide => new("3c8f842c-77e3-41c6-8b76-660f24ab5681");
        public static Guid Satisfide => new("0174fc00-4f04-4cfa-8f9b-d44555d2c467");
        public static Guid Acceptable => new("9714a44e-e4fb-4447-a3c1-440dd30ceed0");
        public static Guid Unsatisfide => new("2b9e2077-4142-4df3-9aca-a8420a0a9d4d");
        public static Guid VeryUnsatisfide => new("22318c06-38d9-4ca2-941d-1eddf2838385");
    }
    public struct StumbleType
    {
        public static Guid RedumpMortgage => new("f4f4fd7d-74ce-4a6d-b289-9e8f338428ec");
        public static Guid Close => new("22318c06-38d9-4ca2-941d-1eddf2838385");
        public static Guid RegularPartly => new("67da6278-1097-40f4-b06a-5b65a5af1893");
        public static Guid Stumbled => new("d2c292bf-58be-4838-8e06-56f1f737fe5d");
        public static Guid Regular => new("fbb18417-f3fa-4fbc-9b53-190078a6ef94");
        public static Guid NotRegular => new("aa46dfe3-8058-427d-aff3-bf66402d6bd4");
    }
    public struct Solvency
    {
        public static Guid LowerClass => new("4ff7170a-cfa2-4ffc-b452-f7a53a17b147");
        public static Guid UpperClass => new("ec3ad12c-230c-49f4-8014-f4df5f2f85ed");
        public static Guid MiddleClass => new("7a33be1d-a945-4004-ba33-e54f63f497de");
        public static Guid UpperMiddleClass => new("d617840b-f549-405f-b758-759740876034");
        public static Guid LowerMiddleClass => new("f535ced0-5e60-4d9b-81cc-5d392c635096");
        public static Guid Deceased => new("bcfb3770-afd8-4aa0-9386-6384e5fdd0d2");
        public static Guid Undefined => new("13cd65bb-0262-461e-94ca-ff534e91cbe2");
    }

    public struct TriggerType
    {
        public static Guid OnClick => new("817e4b7f-c425-4774-ba93-ca4aedea160d");
        public static Guid OnCreate => new("2bab8ff2-8ddf-4691-b704-7c29526605f2");
        public static Guid OnUpdate => new("125572ee-3743-4d03-b4f8-f003fa3d22ad");
        public static Guid OnDelete => new("2fdd7ad8-a254-490e-ba65-cd4971811658");
        public static Guid OnView => new("8e40406e-7ab8-405c-b6c8-3e4cd7db5ef3");
        public static Guid OnActivate => new("51a7be15-439d-4300-aea3-0b6c9dd91b57");
        public static Guid DeActivate => new("4ea813d4-a0c6-4ee2-97d6-8f5756e23896");
        public static Guid OnSubmit => new("78055fed-079a-43b2-a0b3-69fc7f38744d");
    }

    public struct ReactionType
    {
        public static Guid Like => new("817e4b7f-c425-4774-ba93-ca4aedea160d");
        public static Guid Celebrate => new("2bab8ff2-8ddf-4691-b704-7c29526605f2");
    }

    public struct Country
    {
        public static Guid SaudiArabia => new("1A7C3F7A-EA0B-4F23-9C49-68317F5A3AB0");
    }
    public struct Team
    {
        public static Guid ContactSupport => new("3c8f842c-77e3-41c6-8b76-660f24ab5681");
    }
    public struct Entities
    {
        public struct Application
        {
            public static Guid CallBill => new("91b2ee8a-4126-4589-901b-993688d9efda");
            public static Guid CallQuality => new("cad78edc-6da3-4b03-8cfc-13ddcc229440");
            public static Guid CallQualityCriteria => new("73218b82-b075-4b0d-a3f0-fcb4a456e96e");
            public static Guid CallQualityCriteriaPart => new("316168b0-dd10-457a-9689-a9ce82be9073");
            public static Guid Contact => new("96bd359e-5060-41b7-b15c-041245df0a92");
            public static Guid Contract => new("872fb63a-a1ab-4031-ac30-5653b356fde9");
            public static Guid HistoricalCall => new("63e0a8a6-43e3-4718-b08a-e0f80f7f7f56");
            public static Guid HistoricalCallComment => new("38ae3821-99b4-4167-813f-a51c9a36af92");
            public static Guid Payment => new("bec9374f-79bd-4b85-a476-5ac32f5e7e2f");
            public static Guid PersonalInfo => new("38a84837-16ce-4fbb-99b2-5a595c95ecf0");
            public static Guid ScheduledCall => new("83f6c13b-64c4-4ad1-af46-f55a7118e2c0");
            public static Guid Setting => new("6509294e-df52-4524-826c-10e58e5b67d5");
            public static Guid SystemProgress => new("ba4c4a9e-7a21-4183-ae97-4bc322581b20");
        }
        public struct Entity
        {
            public static Guid EntityType => new("b730380a-8f15-423a-884f-c2249eb2d58d");
            public static Guid DynamicFunction => new("a56cec1b-44e5-4fa3-b42d-485ec5eb37aa");
            public static Guid DynamicReport => new("a596f09b-e63f-42d8-86ca-875fd6eaf6d3");
            public static Guid EntityActionType => new("cb4ef3ce-fae8-4828-881c-f4b02f96f855");
            public static Guid EntityFieldActionType => new("708593c8-baca-409c-b9be-325e05f48123");
        }
        public struct Identity
        {
            public static Guid Role => new("b67c5548-7098-48de-a86c-2ced19a40471");
            public static Guid RolePermission => new("38920507-73c0-4035-8639-d4f66bee9952");
            public static Guid User => new("296f3487-44a7-4237-96d0-c2aeaa7ecaeb");
            public static Guid Leaders => new("11111111-44a7-4237-96d0-c2aeaa7ecaeb");
            public static Guid UserCategoryPath => new("90e20a39-b72b-418b-beff-658ad0fbd7b5");
            public static Guid UserPermission => new("04e4943a-0d56-4ea9-b878-926d05c435f9");
            public static Guid UserSetting => new("d1fded5f-88ca-4537-80f8-ddb6bf5b6ed5");
            public static Guid UserTeams => new("7e532c9d-8101-4294-8c73-cf04f0c64c95");

            public static Guid Employee => new("d7f3d652-4882-4029-a810-5e4fc1d25fa3");
            public static Guid ContactSupport => new("60f87633-fbbd-49bc-8c7d-73b53af285c7");
        }
        public struct Log
        {
            public static Guid ContactUploadingLog => new("90431599-2fbf-4c2c-98ee-d20c469551bc");
            public static Guid ContractHistory => new("1fcc2bfb-bb08-44f3-b99e-804c6ab5df8d");
            public static Guid PersonalInfoLog => new("77527367-7cfd-416c-be58-9780bdad879b");
            public static Guid SMSSentLog => new("f91ccfaf-9260-4baf-b9df-9f27715ac092");
        }
        public struct Lookup
        {
            public static Guid AVAYAAURACampaignPredictive => new("8ea9780e-111a-4c20-bdc9-700fb3d28d85");
            public static Guid CallStatus => new("6fc1c72c-780a-4877-bf65-803f913d5190");
            public static Guid SubCallStatus => new("b0da4122-3c89-4237-b170-311c887cc7e7");
            public static Guid CallType => new("7c535ca0-56c0-4b53-a3b3-c66ef12d389e");
            public static Guid Campaign => new("1e648ce3-267c-44ad-940a-9aa3148a8519");
            public static Guid Category => new("1c28bc30-d216-4812-a292-8e8e2c02c5e1");
            public static Guid CategoryPath => new("357d1ce2-3631-4021-9f49-ddb8be7fbd0f");
            public static Guid City => new("caec39b5-2bfe-43d7-8fb8-ccd455f66312");
            public static Guid ConditionFor => new("6ffe76fa-7c3b-4ff9-9fb5-e9851beb5327");
            public static Guid ConditionType => new("caecbb8c-a116-49c8-8d05-1e75ca9b573f");
            public static Guid ContractStatus => new("dacf4e52-019e-4bda-ae72-f22b135cc9b8");
            public static Guid ContractType => new("70ebe78c-f361-46e6-be83-faf7affd693e");
            public static Guid Country => new("f0a695d9-a73c-4e2c-992d-c23c85853e70");
            public static Guid EmployerSector => new("4605c6b9-afdc-4baa-bac9-2ed38a16cf8e");
            public static Guid EmployerType => new("e857c3ca-be15-41af-8f93-306b94c85cfc");
            public static Guid FieldType => new("2632b95e-2ff7-4b4f-9422-3ecebd856fc9");
            public static Guid Gender => new("357ab406-6e13-48f1-be88-6c1cbd97654d");
            public static Guid InsuranceStatus => new("f9ffd0b6-1223-43a9-b214-d5d0b9498902");
            public static Guid LoanTimeStatus => new("1a9b70a2-1d02-49bc-9aeb-64cee6cb9b09");
            public static Guid Nationality => new("50e6cef1-da4e-4bb3-8e26-c8d80ce41e20");
            public static Guid PaymentGateway => new("bc800b0e-8743-4e3d-86a3-7ce3946bc76b");
            public static Guid PaymentMethod => new("cb444b0b-2c22-41bd-86db-131e401e5f71");
            public static Guid Permission => new("92aabbd9-b890-4118-9ce8-c8e6862dc11e");
            public static Guid Priority => new("c32068b2-e391-460d-9e08-1d92bc33746b");
            public static Guid RegistrationType => new("60c47180-b24f-47ca-bd37-77edfaf257f0");
            public static Guid RetirementStatus => new("f7a5b0cb-b0c7-4744-81c3-d9b3f67a6612");
            public static Guid Satisfaction => new("48564202-568f-4e84-94d0-518cc61631cd");
            public static Guid SettingType => new("b3918956-0106-4c6a-8e79-b02a5d9759c5");
            public static Guid StumbleType => new("25254ee1-f98c-4800-a3be-bff0f306b6bf");
            public static Guid Solvency => new("e8aa01af-6578-4912-b9cb-6601779ec1b8");
            //public static Guid Survey => new("n8aa01af-6578-4912-b9cb-6601779ec1b8");
            public static Guid Team => new("376ccb5d-408f-4c15-b0f6-289f5b4c2f99");
            public static Guid TriggerType => new("dd6a0c1a-9c1b-4f8b-af33-1907c0e6e024");
            public static Guid Centers => new("0be8818f-5c65-4de3-829f-6ab63ab92650");
            public static Guid NHCProject => new("fb5c901f-4e97-4df3-9aa4-9596ef10c1d0");
            public static Guid Cities => new("fa9cf73b-7813-4135-97ec-355db1be87ab");
            public static Guid Suburbs => new("8a4966f3-e1e0-4e1b-b15a-cdfe57af6e30");
            public static Guid Projects => new("480a2eb9-d68f-45c5-afd3-5ccb9295da3f");

        }

    }

    public static class EntitiesString
    {
        public class Application
        {
            public const string CallBill = "91b2ee8a-4126-4589-901b-993688d9efda";
            public const string CallQuality = "cad78edc-6da3-4b03-8cfc-13ddcc229440";
            public const string CallQualityCriteria = "73218b82-b075-4b0d-a3f0-fcb4a456e96e";
            public const string CallQualityCriteriaPart = "316168b0-dd10-457a-9689-a9ce82be9073";
            public const string Contact = "96bd359e-5060-41b7-b15c-041245df0a92";
            public const string Contract = "872fb63a-a1ab-4031-ac30-5653b356fde9";
            public const string HistoricalCall = "63e0a8a6-43e3-4718-b08a-e0f80f7f7f56";
            public const string HistoricalCallComment = "38ae3821-99b4-4167-813f-a51c9a36af92";
            public const string Payment = "bec9374f-79bd-4b85-a476-5ac32f5e7e2f";
            public const string PersonalInfo = "38a84837-16ce-4fbb-99b2-5a595c95ecf0";
            public const string ScheduledCall = "83f6c13b-64c4-4ad1-af46-f55a7118e2c0";
            public const string Setting = "6509294e-df52-4524-826c-10e58e5b67d5";
            public const string SystemProgress = "ba4c4a9e-7a21-4183-ae97-4bc322581b20";
        }
        public struct ConditionType
        {
            public const string Equal = "7cbdb20f-8790-4193-8bca-4adb1ea743a9";
            public const string NotEqual = "df540314-dfa9-4a2d-bc82-863bbb77b271";
            public const string NotNull = "0f979f1c-4419-420e-81d2-0ce99048049f";
            public const string Null = "47d75e03-d7a1-467f-a870-5cf451b552a6";
            public const string Contain = "059f4279-53da-4d31-bac3-cf75092b9e44";
            public const string LessThan = "b47b64a4-da48-4d66-9972-532c8f23eec3";
            public const string LessThanOrEqual = "f29b0cea-10f5-4a62-90e2-6377f644b2a3";
            public const string MoreThan = "c03cfa6a-8125-458b-85dc-babc046417bf";
            public const string MoreThanOrEqual = "55899e39-2eb5-42c4-a090-f719457b865f";
            public const string In = "45fa4a17-8a36-4a2b-a5fb-c389f65c6bf9";
        }
        public class Entity
        {
            public const string EntityType = "b730380a-8f15-423a-884f-c2249eb2d58d";
            public const string DynamicFunction = "a56cec1b-44e5-4fa3-b42d-485ec5eb37aa";
            public const string DynamicReport = "a596f09b-e63f-42d8-86ca-875fd6eaf6d3";
            public const string EntityActionType = "cb4ef3ce-fae8-4828-881c-f4b02f96f855";
            public const string EntityFieldActionType = "708593c8-baca-409c-b9be-325e05f48123";
        }
        public class Identity
        {
            public const string Role = "b67c5548-7098-48de-a86c-2ced19a40471";
            public const string RolePermission = "38920507-73c0-4035-8639-d4f66bee9952";
            public const string User = "296f3487-44a7-4237-96d0-c2aeaa7ecaeb";
            public const string Leaders = "11111111-44a7-4237-96d0-c2aeaa7ecaeb";
            public const string UserCategoryPath = "90e20a39-b72b-418b-beff-658ad0fbd7b5";
            public const string UserPermission = "04e4943a-0d56-4ea9-b878-926d05c435f9";
            public const string UserSetting = "d1fded5f-88ca-4537-80f8-ddb6bf5b6ed5";
            public const string UserTeams = "7e532c9d-8101-4294-8c73-cf04f0c64c95";
            public const string Employee = "d7f3d652-4882-4029-a810-5e4fc1d25fa3";
            public const string ContactSupport = "60f87633-fbbd-49bc-8c7d-73b53af285c7";
        }
        public class Log
        {
            public const string ContactUploadingLog = "90431599-2fbf-4c2c-98ee-d20c469551bc";
            public const string ContractHistory = "1fcc2bfb-bb08-44f3-b99e-804c6ab5df8d";
            public const string PersonalInfoLog = "77527367-7cfd-416c-be58-9780bdad879b";
            public const string SMSSentLog = "f91ccfaf-9260-4baf-b9df-9f27715ac092";
        }
        public class Lookup
        {
            public const string AVAYAAURACampaignPredictive = "8ea9780e-111a-4c20-bdc9-700fb3d28d85";
            public const string CallStatus = "6fc1c72c-780a-4877-bf65-803f913d5190";
            public const string SubCallStatus = "b0da4122-3c89-4237-b170-311c887cc7e7";
            public const string CallType = "7c535ca0-56c0-4b53-a3b3-c66ef12d389e";
            public const string Campaign = "1e648ce3-267c-44ad-940a-9aa3148a8519";
            public const string Category = "1c28bc30-d216-4812-a292-8e8e2c02c5e1";
            public const string CategoryPath = "357d1ce2-3631-4021-9f49-ddb8be7fbd0f";
            public const string City = "caec39b5-2bfe-43d7-8fb8-ccd455f66312";
            public const string ConditionFor = "6ffe76fa-7c3b-4ff9-9fb5-e9851beb5327";
            public const string ConditionType = "caecbb8c-a116-49c8-8d05-1e75ca9b573f";
            public const string ContractStatus = "dacf4e52-019e-4bda-ae72-f22b135cc9b8";
            public const string ContractType = "70ebe78c-f361-46e6-be83-faf7affd693e";
            public const string Country = "f0a695d9-a73c-4e2c-992d-c23c85853e70";
            public const string EmployerSector = "4605c6b9-afdc-4baa-bac9-2ed38a16cf8e";
            public const string EmployerType = "e857c3ca-be15-41af-8f93-306b94c85cfc";
            public const string FieldType = "2632b95e-2ff7-4b4f-9422-3ecebd856fc9";
            public const string Gender = "357ab406-6e13-48f1-be88-6c1cbd97654d";
            public const string InsuranceStatus = "f9ffd0b6-1223-43a9-b214-d5d0b9498902";
            public const string LoanTimeStatus = "1a9b70a2-1d02-49bc-9aeb-64cee6cb9b09";
            public const string Nationality = "50e6cef1-da4e-4bb3-8e26-c8d80ce41e20";
            public const string PaymentGateway = "bc800b0e-8743-4e3d-86a3-7ce3946bc76b";
            public const string PaymentMethod = "cb444b0b-2c22-41bd-86db-131e401e5f71";
            public const string Permission = "92aabbd9-b890-4118-9ce8-c8e6862dc11e";
            public const string Priority = "c32068b2-e391-460d-9e08-1d92bc33746b";
            public const string RegistrationType = "60c47180-b24f-47ca-bd37-77edfaf257f0";
            public const string RetirementStatus = "f7a5b0cb-b0c7-4744-81c3-d9b3f67a6612";
            public const string ReactionType = "92b0b079-771d-4424-854f-7238dd539f3d";
            public const string Satisfaction = "48564202-568f-4e84-94d0-518cc61631cd";
            public const string SettingType = "b3918956-0106-4c6a-8e79-b02a5d9759c5";
            public const string StumbleType = "25254ee1-f98c-4800-a3be-bff0f306b6bf";
            public const string Solvency = "e8aa01af-6578-4912-b9cb-6601779ec1b8";
            public const string Team = "376ccb5d-408f-4c15-b0f6-289f5b4c2f99";
            public const string TriggerType = "dd6a0c1a-9c1b-4f8b-af33-1907c0e6e024";
            public const string ProjectsRegionOne = "b0b1e6bb-b3e9-41c8-ae92-85cb6bd0190a";
            public const string ProjectsRegionTwo = "611d2d36-4850-461e-ae76-14bf9e35043f";
            public const string ProjectsRegionThree = "f5116e80-cdf1-4792-956a-cdc58a64dcd0";
            public const string ProjectsRegionFour = "72dadbfc-4db8-47c5-97c5-6dbbe703e50e";
            public const string ProjectsRegionFive = "0988585a-c4aa-4a0f-9bae-9ffbf32f5cbb";
            public const string CustomProjects1 = "bfc5682d-0dfd-4ee7-a0e6-3c41f7627003";
            public const string CustomProjects2 = "1557857f-c31c-4aae-bf54-1c491efd0520";
            public const string CustomProjects3 = "d6d56872-ab33-42cf-b87c-e099403c036f";
            public const string CustomProjects4 = "6cbd626e-1c2c-4b2d-ac5f-507f6c12c66b";
            public const string CustomProjects5 = "7685c5c7-29f3-45e5-b25d-76f0dc027fa8";
            public const string CustomProjects6 = "db8eedb7-869c-4816-ba41-4cfc93ded35e";
            public const string CustomProjects7 = "804135da-f5d9-4fbf-a980-c29d2ab156aa";
            public const string CustomProjects8 = "65335717-6d80-4e09-beca-b8eeec43483a";
            public const string CustomProjects9 = "5b6e2204-b33a-4d0c-bfc0-893033e5fc5a";
            public const string CustomProjects10 = "745698d9-e46d-4601-933c-26321475f11e";
            public const string CustomProjects11 = "b66a1f9c-adae-410a-a56f-f92aa619dab2";
            public const string CustomProjects12 = "0be8864d-5c65-4de3-829f-6ab63ab92650";
            public const string Centers = "0be8818f-5c65-4de3-829f-6ab63ab92650";
            public const string Cities = "fa9cf73b-7813-4135-97ec-355db1be87ab";
            public const string Suburbs = "8a4966f3-e1e0-4e1b-b15a-cdfe57af6e30";
            public const string Projects = "480a2eb9-d68f-45c5-afd3-5ccb9295da3f";

        }

    }


    public struct OperationTypeOnScheduledCall
    {
        public const string AssignToPredictiveSystem = "097a6baa-305a-4ed9-9606-100b44c256b9";
        public const string ScheduledInSystem = "c0245a05-4870-46f7-90c2-f58b8f026a61";
        public const string DeleteCalls = "a35344e7-ca4a-43aa-af86-5bc029d2705c";
        public const string AssignToSpecificUser = "608ff914-91a8-45fe-b153-d5d3ef55df62";
        public const string ReturnToLatestStatus = "cbf20eed-65ea-4a8a-a34c-57fb6e5ed0cc";
        public const string ChangePriority = "aab20eed-65ea-4a8a-a34c-57fb6e5ed0cc";

    }
}
