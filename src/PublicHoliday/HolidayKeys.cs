namespace PublicHoliday
{
    /// <summary>
    /// The stable identifier of every holiday the library computes, one constant per holiday.
    /// A holiday's key never changes across years, languages or calendars, so it is the way to
    /// find a specific holiday without knowing its date:
    /// <code>
    /// var christmas = calendar.PublicHolidaysInformation(2026)
    ///     .Single(h => h.HolidayKey == HolidayKeys.Christmas);
    /// </code>
    /// Holidays observed by several countries share one key (<see cref="Christmas"/>,
    /// <see cref="GoodFriday"/>); a country whose holiday differs has its own, suffixed with the
    /// ISO country code (<see cref="WorkersDayZA"/>, <see cref="MidsummerDayLV"/>). The same key
    /// names the holiday's translation row in each Localization/Names resource file.
    ///
    /// This class is the defining list: the holiday definitions reference these constants, and
    /// TestHolidayKeys verifies that the constants and the holidays every calendar actually
    /// produces stay in step, in both directions.
    ///
    /// The regions mirror the HolidayDefinitions folders - the shared Christian/Common/Islamic
    /// definitions first, then one region per country - with keys alphabetical inside each; a
    /// key defined per-country but used by several sits in "Shared by several countries".
    /// </summary>
    public static class HolidayKeys
    {
        #region Christian (shared feasts)
        /// <summary>All Saints / All Saints Day / All Saints' Day.</summary>
        public const string AllSaints = "AllSaints";
        /// <summary>Ascension.</summary>
        public const string Ascension = "Ascension";
        /// <summary>Assumption / Assumption Day / Dormition of the Mother of God.</summary>
        public const string Assumption = "Assumption";
        /// <summary>Christmas / Christmas (Orthodox) / Christmas Day.</summary>
        public const string Christmas = "Christmas";
        /// <summary>Christmas Eve / Christmas Eve (Orthodox).</summary>
        public const string ChristmasEve = "ChristmasEve";
        /// <summary>Clean Monday.</summary>
        public const string CleanMonday = "CleanMonday";
        /// <summary>Corpus Christi.</summary>
        public const string CorpusChristi = "CorpusChristi";
        /// <summary>Easter / Easter Sunday.</summary>
        public const string Easter = "Easter";
        /// <summary>Easter Monday.</summary>
        public const string EasterMonday = "EasterMonday";
        /// <summary>Epiphany.</summary>
        public const string Epiphany = "Epiphany";
        /// <summary>Good Friday / Great Friday.</summary>
        public const string GoodFriday = "GoodFriday";
        /// <summary>Immaculate Conception.</summary>
        public const string ImmaculateConception = "ImmaculateConception";
        /// <summary>Maundy Thursday.</summary>
        public const string MaundyThursday = "MaundyThursday";
        /// <summary>Whit Monday.</summary>
        public const string PentecostMonday = "PentecostMonday";
        /// <summary>Reformation Day.</summary>
        public const string ReformationDay = "ReformationDay";
        /// <summary>Feast of Saints Peter and Paul - Czechoslovakia, until 1951.</summary>
        public const string SaintPeterAndPaul = "SaintPeterAndPaul";
        /// <summary>St Stephen's Day.</summary>
        public const string SaintStephensDay = "SaintStephensDay";
        /// <summary>St Patrick's Day / St. Patrick's Day.</summary>
        public const string StPatricksDay = "StPatricksDay";
        /// <summary>Pentecost / Whit Sunday.</summary>
        public const string WhitSunday = "WhitSunday";
        #endregion

        #region Common (shared secular holidays)
        /// <summary>Armistice Day.</summary>
        public const string Armistice = "Armistice";
        /// <summary>Day after Labour Day - the shared default; every country using it overrides with its own key (LabourDaySecondSI/ME/RS).</summary>
        public const string DayAfterLabourDay = "DayAfterLabourDay";
        /// <summary>Day After New Year.</summary>
        public const string DayAfterNewYear = "DayAfterNewYear";
        /// <summary>Labour Day.</summary>
        public const string LabourDay = "LabourDay";
        /// <summary>New Year / New Year's Day.</summary>
        public const string NewYear = "NewYear";
        /// <summary>New Year's Eve.</summary>
        public const string NewYearsEve = "NewYearsEve";
        /// <summary>Victory in Europe Day.</summary>
        public const string VictoryInEuropeDay = "VictoryInEuropeDay";
        /// <summary>International Women's Day.</summary>
        public const string WomensDay = "WomensDay";
        #endregion

        #region Islamic (shared, Umm al-Qura)
        /// <summary>Eid al-Adha.</summary>
        public const string EidAlAdha = "EidAlAdha";
        /// <summary>Eid al-Fitr.</summary>
        public const string EidAlFitr = "EidAlFitr";
        #endregion

        #region Shared by several countries
        /// <summary>All Souls' Day.</summary>
        public const string AllSouls = "AllSouls";
        /// <summary>ANZAC Day.</summary>
        public const string AnzacDay = "AnzacDay";
        /// <summary>Boxing Day.</summary>
        public const string BoxingDay = "BoxingDay";
        /// <summary>State Funeral of Queen Elizabeth II.</summary>
        public const string QueenElizabethFuneral = "QueenElizabethFuneral";
        /// <summary>Thanksgiving / Thanksgiving Day.</summary>
        public const string Thanksgiving = "Thanksgiving";
        #endregion

        #region Australia
        /// <summary>Australia Day.</summary>
        public const string AustraliaDay = "AustraliaDay";
        /// <summary>Bank Holiday.</summary>
        public const string BankHolidayNSW = "BankHolidayNSW";
        /// <summary>Canberra Day.</summary>
        public const string CanberraDayAU = "CanberraDayAU";
        /// <summary>Family And Community Day.</summary>
        public const string FamilyCommunityDayAU = "FamilyCommunityDayAU";
        /// <summary>King's Birthday.</summary>
        public const string KingsBirthdayAU = "KingsBirthdayAU";
        /// <summary>Melbourne Cup.</summary>
        public const string MelbourneCupAU = "MelbourneCupAU";
        /// <summary>National Day of Mourning.</summary>
        public const string NationalDayOfMourningAU2022 = "NationalDayOfMourningAU2022";
        /// <summary>Picnic Day.</summary>
        public const string PicnicDayAU = "PicnicDayAU";
        /// <summary>Proclamation Day.</summary>
        public const string ProclamationDaySA = "ProclamationDaySA";
        /// <summary>Queen's Birthday - the name of the monarch's birthday until 2022.</summary>
        public const string QueensBirthdayAU = "QueensBirthdayAU";
        /// <summary>Western Australia Day.</summary>
        public const string WesternAustraliaDay = "WesternAustraliaDay";
        #endregion

        #region Austria
        /// <summary>National Day.</summary>
        public const string NationalDayAT = "NationalDayAT";
        #endregion

        #region Belgium
        /// <summary>Belgian National Day.</summary>
        public const string BelgianNationalDay = "BelgianNationalDay";
        #endregion

        #region Brazil
        /// <summary>Carnival Monday.</summary>
        public const string CarnivalBR1 = "CarnivalBR1";
        /// <summary>Carnival Tuesday.</summary>
        public const string CarnivalBR2 = "CarnivalBR2";
        /// <summary>Independence Day.</summary>
        public const string IndependenceDayBR = "IndependenceDayBR";
        /// <summary>Our Lady of Aparecida.</summary>
        public const string OurLadyAparecidaBR = "OurLadyAparecidaBR";
        /// <summary>Republic Day.</summary>
        public const string RepublicDayBR = "RepublicDayBR";
        /// <summary>Tiradentes Day.</summary>
        public const string TiradentesBR = "TiradentesBR";
        #endregion

        #region Canada
        /// <summary>Aboriginal Day.</summary>
        public const string AboriginalDayCA = "AboriginalDayCA";
        /// <summary>Canada Day.</summary>
        public const string CanadaDay = "CanadaDay";
        /// <summary>Civic Holiday.</summary>
        public const string CivicHolidayCA = "CivicHolidayCA";
        /// <summary>Day After Christmas.</summary>
        public const string DayAfterChristmas = "DayAfterChristmas";
        /// <summary>Day Before Christmas.</summary>
        public const string DayBeforeChristmas = "DayBeforeChristmas";
        /// <summary>Day Before New Year.</summary>
        public const string DayBeforeNewYear = "DayBeforeNewYear";
        /// <summary>Discovery Day.</summary>
        public const string DiscoveryDayCA = "DiscoveryDayCA";
        /// <summary>Dollard Day - the pre-2003 name of Quebec's National Patriots' Day.</summary>
        public const string DollardDay = "DollardDay";
        /// <summary>Dominion Day - the pre-1982 name of Canada Day.</summary>
        public const string DominionDay = "DominionDay";
        /// <summary>Family Day.</summary>
        public const string FamilyDayCA = "FamilyDayCA";
        /// <summary>Gold Cup Parade Day.</summary>
        public const string GoldCupParadeDayCA = "GoldCupParadeDayCA";
        /// <summary>National Holiday.</summary>
        public const string NationalHolidayCA = "NationalHolidayCA";
        /// <summary>Quebec National Holiday.</summary>
        public const string NationalHolidayQuebec = "NationalHolidayQuebec";
        /// <summary>National Patriots' Day.</summary>
        public const string NationalPatriotDay = "NationalPatriotDay";
        /// <summary>Orangemen's Day.</summary>
        public const string OrangemensDayCA = "OrangemensDayCA";
        /// <summary>Remembrance Day.</summary>
        public const string RemembranceDayCA = "RemembranceDayCA";
        /// <summary>Saint George's Day.</summary>
        public const string StGeorgesDayCA = "StGeorgesDayCA";
        /// <summary>National Day For Truth And Reconciliation.</summary>
        public const string TruthReconciliationDayCA = "TruthReconciliationDayCA";
        /// <summary>Victoria Day.</summary>
        public const string VictoriaDayCA = "VictoriaDayCA";
        #endregion

        #region Croatia
        /// <summary>Anti-Fascist Struggle Day.</summary>
        public const string AntiFascistStruggleDayHR = "AntiFascistStruggleDayHR";
        /// <summary>National Day.</summary>
        public const string NationalDayHR = "NationalDayHR";
        /// <summary>Remembrance Day.</summary>
        public const string RemembranceDayHR = "RemembranceDayHR";
        /// <summary>Victory and Homeland Thanksgiving Day.</summary>
        public const string VictoryDayHR = "VictoryDayHR";
        #endregion

        #region CzechRepublic
        /// <summary>Day of the Establishment of the Independent Czech State.</summary>
        public const string CzechEstablishmentDay = "CzechEstablishmentDay";
        /// <summary>Czech Statehood Day.</summary>
        public const string CzechStatehoodDay = "CzechStatehoodDay";
        /// <summary>Jan Hus Day.</summary>
        public const string JanHusDayCZ = "JanHusDayCZ";
        #endregion

        #region Czechoslovakia
        /// <summary>St Cyril and Methodius Day.</summary>
        public const string CyrilAndMethodiusDay = "CyrilAndMethodiusDay";
        /// <summary>Struggle for Freedom and Democracy Day.</summary>
        public const string FreedomAndDemocracyDayCS = "FreedomAndDemocracyDayCS";
        /// <summary>Day of the Establishment of the Independent Czecho-Slovak State.</summary>
        public const string IndependentCzechoslovakStateDayCS = "IndependentCzechoslovakStateDayCS";
        /// <summary>Nationalization Day - Czechoslovakia, 1952-1974.</summary>
        public const string NationalizationDayCS = "NationalizationDayCS";
        /// <summary>Day of Liberation of Czechoslovakia by the Soviet Army.</summary>
        public const string SovietLiberationDayCS = "SovietLiberationDayCS";
        #endregion

        #region Denmark
        /// <summary>Constitution Day.</summary>
        public const string ConstitutionDayDK = "ConstitutionDayDK";
        /// <summary>Day after Ascension.</summary>
        public const string DayAfterAscensionDK = "DayAfterAscensionDK";
        /// <summary>General Prayer Day.</summary>
        public const string GeneralPrayerDayDK = "GeneralPrayerDayDK";
        #endregion

        #region Estonia
        /// <summary>Independence Day.</summary>
        public const string IndependenceDayEE = "IndependenceDayEE";
        /// <summary>Midsummer Day.</summary>
        public const string MidsummerDayEE = "MidsummerDayEE";
        /// <summary>Day of Restoration of Independence.</summary>
        public const string RestorationOfIndependenceDayEE = "RestorationOfIndependenceDayEE";
        /// <summary>Victory Day.</summary>
        public const string VictoryDayEE = "VictoryDayEE";
        #endregion

        #region Finland
        /// <summary>Independence Day.</summary>
        public const string IndependenceDayFI = "IndependenceDayFI";
        /// <summary>Midsummer Day.</summary>
        public const string MidsummerDayFI = "MidsummerDayFI";
        /// <summary>Midsummer Eve.</summary>
        public const string MidsummerEveFI = "MidsummerEveFI";
        #endregion

        #region France
        /// <summary>Abolition of slavery.</summary>
        public const string AbolitionSlaveryGuadeloupeFR = "AbolitionSlaveryGuadeloupeFR";
        /// <summary>Abolition of slavery.</summary>
        public const string AbolitionSlaveryGuyaneFR = "AbolitionSlaveryGuyaneFR";
        /// <summary>Abolition of slavery.</summary>
        public const string AbolitionSlaveryLaReunionFR = "AbolitionSlaveryLaReunionFR";
        /// <summary>Abolition of slavery.</summary>
        public const string AbolitionSlaveryMartiniqueFR = "AbolitionSlaveryMartiniqueFR";
        /// <summary>Abolition of slavery.</summary>
        public const string AbolitionSlaveryMayotteFR = "AbolitionSlaveryMayotteFR";
        /// <summary>Abolition of slavery.</summary>
        public const string AbolitionSlaverySaintBarthelemyFR = "AbolitionSlaverySaintBarthelemyFR";
        /// <summary>Abolition of slavery.</summary>
        public const string AbolitionSlaverySaintMartinFR = "AbolitionSlaverySaintMartinFR";
        /// <summary>Autonomy Day.</summary>
        public const string AutonomyDayFR = "AutonomyDayFR";
        /// <summary>Bastille Day.</summary>
        public const string BastilleDay = "BastilleDay";
        /// <summary>Citizenship Day.</summary>
        public const string CitizenshipDayFR = "CitizenshipDayFR";
        /// <summary>Peter Chanel day.</summary>
        public const string PeterChanelFR = "PeterChanelFR";
        /// <summary>Territory Festival.</summary>
        public const string TerritoryFestivalDayFR = "TerritoryFestivalDayFR";
        /// <summary>Victor Schoelcher's Feast.</summary>
        public const string VictorSchoelcherDayFR = "VictorSchoelcherDayFR";
        #endregion

        #region Germany
        /// <summary>East German Uprising Memorial Day.</summary>
        public const string EastGermanUprisingDE = "EastGermanUprisingDE";
        /// <summary>German Unity Day.</summary>
        public const string GermanUnityDE = "GermanUnityDE";
        /// <summary>Liberation Day.</summary>
        public const string LiberationDayDE = "LiberationDayDE";
        /// <summary>Repentance Day.</summary>
        public const string RepentanceDayDE = "RepentanceDayDE";
        /// <summary>World Children's Day.</summary>
        public const string WorldChildrensDayDE = "WorldChildrensDayDE";
        #endregion

        #region Greece
        /// <summary>Independence Day.</summary>
        public const string GreekIndependenceDay = "GreekIndependenceDay";
        /// <summary>Ochi Day.</summary>
        public const string OchiDayGR = "OchiDayGR";
        /// <summary>Glorifying Mother of God.</summary>
        public const string SynaxisMotherOfGodGR = "SynaxisMotherOfGodGR";
        #endregion

        #region Hungary
        /// <summary>1848 Revolution Memorial Day.</summary>
        public const string NationalDay1848HU = "NationalDay1848HU";
        /// <summary>1956 Revolution Memorial Day.</summary>
        public const string Revolution1956DayHU = "Revolution1956DayHU";
        /// <summary>State Foundation Day.</summary>
        public const string StateFoundationDayHU = "StateFoundationDayHU";
        #endregion

        #region Ireland
        /// <summary>August Holiday.</summary>
        public const string AugustHolidayIE = "AugustHolidayIE";
        /// <summary>Covid-19 Commemoration.</summary>
        public const string Covid19CommemorationIE = "Covid19CommemorationIE";
        /// <summary>June Holiday.</summary>
        public const string JuneHolidayIE = "JuneHolidayIE";
        /// <summary>May Day.</summary>
        public const string MayDayIE = "MayDayIE";
        /// <summary>Millennium.</summary>
        public const string MillenniumIE = "MillenniumIE";
        /// <summary>October Holiday.</summary>
        public const string OctoberHolidayIE = "OctoberHolidayIE";
        /// <summary>Saint Brigid's Day.</summary>
        public const string StBrigidsDayIE = "StBrigidsDayIE";
        #endregion

        #region Italy
        /// <summary>Liberation Day.</summary>
        public const string LiberationDayIT = "LiberationDayIT";
        /// <summary>Republic Day.</summary>
        public const string RepublicDayIT = "RepublicDayIT";
        #endregion

        #region Japan
        /// <summary>Autumnal Equinox Day.</summary>
        public const string AutumnalEquinoxDayJP = "AutumnalEquinoxDayJP";
        /// <summary>Children's Day.</summary>
        public const string ChildrensDayJP = "ChildrensDayJP";
        /// <summary>Coming Of Age Day.</summary>
        public const string ComingOfAgeDayJP = "ComingOfAgeDayJP";
        /// <summary>Constitution Memorial Day.</summary>
        public const string ConstitutionMemorialDayJP = "ConstitutionMemorialDayJP";
        /// <summary>Culture Day.</summary>
        public const string CultureDayJP = "CultureDayJP";
        /// <summary>Emperor's Birthday.</summary>
        public const string EmperorsBirthdayJP = "EmperorsBirthdayJP";
        /// <summary>Foundation Day.</summary>
        public const string FoundationDayJP = "FoundationDayJP";
        /// <summary>Greenery Day.</summary>
        public const string GreeneryDayJP = "GreeneryDayJP";
        /// <summary>Health And Sports Day.</summary>
        public const string HealthAndSportsDayJP = "HealthAndSportsDayJP";
        /// <summary>Labour Thanksgiving Day.</summary>
        public const string LabourThanksgivingDayJP = "LabourThanksgivingDayJP";
        /// <summary>Marine Day.</summary>
        public const string MarineDayJP = "MarineDayJP";
        /// <summary>Mountain Day.</summary>
        public const string MountainDayJP = "MountainDayJP";
        /// <summary>Respect For The Aged Day.</summary>
        public const string RespectForTheAgedDayJP = "RespectForTheAgedDayJP";
        /// <summary>Shōwa Day.</summary>
        public const string ShowaDayJP = "ShowaDayJP";
        /// <summary>Vernal Equinox Day.</summary>
        public const string VernalEquinoxDayJP = "VernalEquinoxDayJP";
        #endregion

        #region Kazakhstan
        /// <summary>Capital Day.</summary>
        public const string CapitalDayKZ = "CapitalDayKZ";
        /// <summary>Constitution Day.</summary>
        public const string ConstitutionDayKZ = "ConstitutionDayKZ";
        /// <summary>Defender of the Fatherland Day.</summary>
        public const string DefenderDayKZ = "DefenderDayKZ";
        /// <summary>First President Day.</summary>
        public const string FirstPresidentDayKZ = "FirstPresidentDayKZ";
        /// <summary>Independence Day.</summary>
        public const string IndependenceDayKZ = "IndependenceDayKZ";
        /// <summary>Independence Day Holiday.</summary>
        public const string IndependenceDaySecondKZ = "IndependenceDaySecondKZ";
        /// <summary>Kurban Ait.</summary>
        public const string KurbanAitKZ = "KurbanAitKZ";
        /// <summary>Kazakhstan People's Unity Day.</summary>
        public const string NationUnityDayKZ = "NationUnityDayKZ";
        /// <summary>Nauryz.</summary>
        public const string NauryzKZ1 = "NauryzKZ1";
        /// <summary>Nauryz Holiday.</summary>
        public const string NauryzKZ2 = "NauryzKZ2";
        /// <summary>Nauryz Holiday.</summary>
        public const string NauryzKZ3 = "NauryzKZ3";
        /// <summary>Victory Day.</summary>
        public const string VictoryDayKZ = "VictoryDayKZ";
        #endregion

        #region Latvia
        /// <summary>Day of the Bronze Medal Win.</summary>
        public const string BronzeMedalDayLV = "BronzeMedalDayLV";
        /// <summary>Midsummer Eve.</summary>
        public const string LigoDayLV = "LigoDayLV";
        /// <summary>Midsummer Day.</summary>
        public const string MidsummerDayLV = "MidsummerDayLV";
        /// <summary>Mother's Day.</summary>
        public const string MothersDayLV = "MothersDayLV";
        /// <summary>Pastoral Visit of Pope Francis.</summary>
        public const string PopeFrancisVisitLV = "PopeFrancisVisitLV";
        /// <summary>Proclamation of the Republic of Latvia.</summary>
        public const string ProclamationDayLV = "ProclamationDayLV";
        /// <summary>Restoration of Independence Day.</summary>
        public const string RestorationOfIndependenceDayLV = "RestorationOfIndependenceDayLV";
        /// <summary>Second Day of Christmas.</summary>
        public const string SecondChristmasDayLV = "SecondChristmasDayLV";
        /// <summary>Song and Dance Festival Closing Day.</summary>
        public const string SongAndDanceFestivalLV = "SongAndDanceFestivalLV";
        #endregion

        #region Lithuania
        /// <summary>Father's Day.</summary>
        public const string FathersDayLT = "FathersDayLT";
        /// <summary>St John's Day.</summary>
        public const string MidsummerDayLT = "MidsummerDayLT";
        /// <summary>Mother's Day.</summary>
        public const string MothersDayLT = "MothersDayLT";
        /// <summary>Day of Restoration of Independence of Lithuania.</summary>
        public const string RestorationOfIndependenceLT = "RestorationOfIndependenceLT";
        /// <summary>Day of Restoration of the State of Lithuania.</summary>
        public const string RestorationOfStateLT = "RestorationOfStateLT";
        /// <summary>Statehood Day.</summary>
        public const string StatehoodDayLT = "StatehoodDayLT";
        #endregion

        #region Luxembourg
        /// <summary>Europe Day.</summary>
        public const string EuropeDayLU = "EuropeDayLU";
        /// <summary>National Day.</summary>
        public const string NationalDayLU = "NationalDayLU";
        #endregion

        #region Mexico
        /// <summary>Benito Juárez's Birthday.</summary>
        public const string BenitoJuarezBirthdayMX = "BenitoJuarezBirthdayMX";
        /// <summary>Constitution Day.</summary>
        public const string ConstitutionDayMX = "ConstitutionDayMX";
        /// <summary>Independence Day.</summary>
        public const string IndependenceDayMX = "IndependenceDayMX";
        /// <summary>Presidential Inauguration Holiday.</summary>
        public const string PresidentialInaugurationMX = "PresidentialInaugurationMX";
        /// <summary>Revolution Day.</summary>
        public const string RevolutionDayMX = "RevolutionDayMX";
        #endregion

        #region Montenegro
        /// <summary>Independence Day.</summary>
        public const string IndependenceDayME = "IndependenceDayME";
        /// <summary>Independence Day Holiday.</summary>
        public const string IndependenceDaySecondME = "IndependenceDaySecondME";
        /// <summary>Labour Day Holiday.</summary>
        public const string LabourDaySecondME = "LabourDaySecondME";
        /// <summary>Njegoš Day.</summary>
        public const string NegoshevDayME = "NegoshevDayME";
        /// <summary>Statehood Day.</summary>
        public const string StatehoodDayME = "StatehoodDayME";
        /// <summary>Statehood Day Holiday.</summary>
        public const string StatehoodDaySecondME = "StatehoodDaySecondME";
        #endregion

        #region Netherlands
        /// <summary>King's Day.</summary>
        public const string KingsDayNL = "KingsDayNL";
        /// <summary>Liberation Day.</summary>
        public const string LiberationDayNL = "LiberationDayNL";
        #endregion

        #region NewZealand
        /// <summary>Anniversary Day.</summary>
        public const string AnniversaryDayNZ = "AnniversaryDayNZ";
        /// <summary>King's Birthday.</summary>
        public const string KingsBirthdayNZ = "KingsBirthdayNZ";
        /// <summary>Matariki.</summary>
        public const string MatarikiNZ = "MatarikiNZ";
        /// <summary>Queen Elizabeth II Memorial Day.</summary>
        public const string QueenElizabethMemorialDayNZ2022 = "QueenElizabethMemorialDayNZ2022";
        /// <summary>King's Birthday.</summary>
        public const string QueensBirthdayNZ = "QueensBirthdayNZ";
        /// <summary>Waitangi Day.</summary>
        public const string WaitangiDayNZ = "WaitangiDayNZ";
        #endregion

        #region Norway
        /// <summary>Constitution Day.</summary>
        public const string ConstitutionDayNO = "ConstitutionDayNO";
        #endregion

        #region Poland
        /// <summary>Constitution Day.</summary>
        public const string ConstitutionDayPL = "ConstitutionDayPL";
        /// <summary>Independence Day.</summary>
        public const string IndependenceDayPL = "IndependenceDayPL";
        #endregion

        #region Portugal
        /// <summary>Azores Day.</summary>
        public const string AzoresDayPT = "AzoresDayPT";
        /// <summary>Carnival.</summary>
        public const string CarnivalPT = "CarnivalPT";
        /// <summary>First Octave.</summary>
        public const string FirstOctavePT = "FirstOctavePT";
        /// <summary>Freedom Day.</summary>
        public const string FreedomDayPT = "FreedomDayPT";
        /// <summary>Independence Restoration Day.</summary>
        public const string IndependenceRestorationDayPT = "IndependenceRestorationDayPT";
        /// <summary>Madeira Autonomy Day.</summary>
        public const string MadeiraAutonomyDayPT = "MadeiraAutonomyDayPT";
        /// <summary>Portugal Day.</summary>
        public const string PortugalDayPT = "PortugalDayPT";
        /// <summary>Republic Day.</summary>
        public const string RepublicDayPT = "RepublicDayPT";
        #endregion

        #region Romania
        /// <summary>Children's Day.</summary>
        public const string ChildrensDayRO = "ChildrensDayRO";
        /// <summary>Epiphany.</summary>
        public const string EpiphanyRO = "EpiphanyRO";
        /// <summary>National Day.</summary>
        public const string NationalDayRO = "NationalDayRO";
        /// <summary>St Andrew's Day.</summary>
        public const string SaintAndrewDayRO = "SaintAndrewDayRO";
        /// <summary>Saint John the Baptist.</summary>
        public const string SaintJohnBaptistRO = "SaintJohnBaptistRO";
        /// <summary>Day of the Unification of the Romanian Principalities.</summary>
        public const string UnificationDayRO = "UnificationDayRO";
        #endregion

        #region Serbia
        /// <summary>Labour Day Holiday.</summary>
        public const string LabourDaySecondRS = "LabourDaySecondRS";
        /// <summary>Statehood Day.</summary>
        public const string NationalDayRS1 = "NationalDayRS1";
        /// <summary>Statehood Day Holiday.</summary>
        public const string NationalDayRS2 = "NationalDayRS2";
        #endregion

        #region Slovakia
        /// <summary>Day of Our Lady of the Seven Sorrows.</summary>
        public const string LadySevenSorrowsSK = "LadySevenSorrowsSK";
        /// <summary>Day of the Constitution of the Slovak Republic.</summary>
        public const string SlovakConstitutionDay = "SlovakConstitutionDay";
        /// <summary>Day of the Establishment of the Slovak Republic.</summary>
        public const string SlovakEstablishmentDay = "SlovakEstablishmentDay";
        /// <summary>Slovak National Uprising Anniversary.</summary>
        public const string SlovakNationalUprisingDay = "SlovakNationalUprisingDay";
        #endregion

        #region Slovenia
        /// <summary>Labour Day Holiday.</summary>
        public const string LabourDaySecondSI = "LabourDaySecondSI";
        /// <summary>Statehood Day.</summary>
        public const string NationalDaySI = "NationalDaySI";
        /// <summary>Prešeren Day.</summary>
        public const string PreserenDaySI = "PreserenDaySI";
        /// <summary>Day of Uprising Against Occupation.</summary>
        public const string ResistanceDaySI = "ResistanceDaySI";
        /// <summary>Day of Sovereignty and Unity.</summary>
        public const string UnityDaySI = "UnityDaySI";
        #endregion

        #region SouthAfrica
        /// <summary>Day of Goodwill.</summary>
        public const string DayOfGoodwillZA = "DayOfGoodwillZA";
        /// <summary>Election day.</summary>
        public const string ElectionDayZA2024 = "ElectionDayZA2024";
        /// <summary>Family Day.</summary>
        public const string FamilyDayZA = "FamilyDayZA";
        /// <summary>Freedom Day.</summary>
        public const string FreedomDayZA = "FreedomDayZA";
        /// <summary>Heritage Day.</summary>
        public const string HeritageDayZA = "HeritageDayZA";
        /// <summary>Human Rights Day.</summary>
        public const string HumanRightsDayZA = "HumanRightsDayZA";
        /// <summary>Day of Reconciliation.</summary>
        public const string ReconciliationDayZA = "ReconciliationDayZA";
        /// <summary>Rugby World Cup celebration.</summary>
        public const string RugbyWorldCupZA = "RugbyWorldCupZA";
        /// <summary>National Women's Day.</summary>
        public const string WomensDayZA = "WomensDayZA";
        /// <summary>Workers' Day.</summary>
        public const string WorkersDayZA = "WorkersDayZA";
        /// <summary>Youth Day.</summary>
        public const string YouthDayZA = "YouthDayZA";
        #endregion

        #region Spain
        /// <summary>Constitution Day.</summary>
        public const string ConstitutionDayES = "ConstitutionDayES";
        /// <summary>National Day.</summary>
        public const string NationalDayES = "NationalDayES";
        #endregion

        #region Sweden
        /// <summary>Midsummer Day.</summary>
        public const string MidsummerDaySE = "MidsummerDaySE";
        /// <summary>Midsummer Eve.</summary>
        public const string MidsummerEveSE = "MidsummerEveSE";
        /// <summary>National Day.</summary>
        public const string NationalDaySE = "NationalDaySE";
        #endregion

        #region Switzerland
        /// <summary>Berchtold's Day.</summary>
        public const string Berchtold = "Berchtold";
        /// <summary>Geneva Fast.</summary>
        public const string GenevaPrayDay = "GenevaPrayDay";
        /// <summary>Republic Day.</summary>
        public const string NeuchatelRepublicDay = "NeuchatelRepublicDay";
        /// <summary>Saint Joseph's Day.</summary>
        public const string StJoseph = "StJoseph";
        /// <summary>Ascension Day.</summary>
        public const string SwissAscension = "SwissAscension";
        /// <summary>National Day.</summary>
        public const string SwissNationalDay = "SwissNationalDay";
        #endregion

        #region Turkey
        /// <summary>Democracy and National Unity Day.</summary>
        public const string DemocracyNationalUnityDayTR = "DemocracyNationalUnityDayTR";
        /// <summary>National Sovereignty and Children's Day.</summary>
        public const string NationalSovereigntyChildrensDayTR = "NationalSovereigntyChildrensDayTR";
        /// <summary>Republic Day.</summary>
        public const string RepublicDayTR = "RepublicDayTR";
        /// <summary>Victory Day.</summary>
        public const string VictoryDayTR = "VictoryDayTR";
        /// <summary>Youth and Sports Day.</summary>
        public const string YouthAndSportsDayTR = "YouthAndSportsDayTR";
        #endregion

        #region UnitedKingdom
        /// <summary>Battle of the Boyne.</summary>
        public const string BattleOfTheBoyneUK = "BattleOfTheBoyneUK";
        /// <summary>Coronation of King Charles III.</summary>
        public const string CoronationUK2023 = "CoronationUK2023";
        /// <summary>Queen's Diamond Jubilee.</summary>
        public const string DiamondJubileeUK = "DiamondJubileeUK";
        /// <summary>Early May.</summary>
        public const string EarlyMayUK = "EarlyMayUK";
        /// <summary>Golden Jubilee.</summary>
        public const string GoldenJubileeUK = "GoldenJubileeUK";
        /// <summary>New Year Holiday.</summary>
        public const string NewYearHolidayScotland = "NewYearHolidayScotland";
        /// <summary>Queen's Platinum Jubilee.</summary>
        public const string PlatinumJubileeUK = "PlatinumJubileeUK";
        /// <summary>Royal Wedding.</summary>
        public const string RoyalWeddingUK2011 = "RoyalWeddingUK2011";
        /// <summary>Spring.</summary>
        public const string SpringUK = "SpringUK";
        /// <summary>St Andrew's Day.</summary>
        public const string StAndrewsDayUK = "StAndrewsDayUK";
        /// <summary>Summer / Summer Holiday.</summary>
        public const string SummerUK = "SummerUK";
        /// <summary>World Cup.</summary>
        public const string WorldCupUK2026 = "WorldCupUK2026";
        #endregion

        #region USA
        /// <summary>Columbus Day.</summary>
        public const string ColumbusDay = "ColumbusDay";
        /// <summary>Independence Day.</summary>
        public const string IndependenceDay = "IndependenceDay";
        /// <summary>Juneteenth.</summary>
        public const string Juneteenth = "Juneteenth";
        /// <summary>Labor Day.</summary>
        public const string LaborDay = "LaborDay";
        /// <summary>Martin Luther King Day.</summary>
        public const string MartinLutherKing = "MartinLutherKing";
        /// <summary>Memorial Day.</summary>
        public const string MemorialDay = "MemorialDay";
        /// <summary>President's Day.</summary>
        public const string PresidentsDay = "PresidentsDay";
        /// <summary>Veteran's Day.</summary>
        public const string VeteransDay = "VeteransDay";
        #endregion
    }
}
