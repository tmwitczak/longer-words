﻿// //////////////////////////////////////////////////// Usings //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ///////////////////////////////////// Class: CommandManager //
public
class CommandManager
        : MonoBehaviour
{
    // ================================== Public interface < ==//
    // -------------------------------------- Behaviour << --==//
    public class Commands
    {
        public string locate;
        public string attack;
    }

    public
    Commands register(Enemy gameObject)
    {
        Commands commands = new Commands();

        // Generate LOCATE command
        commands.locate += locateSymbol;
        for (int i = 0; i < 2; i++)
        {
            commands.locate += (char)('0' + Random.Range(0, 10));
        }

        // Generate ATTACK command
        commands.attack += attackSymbol;
        // for (int i = 0; i < 10; i++)
        // {
        //     commands.attack += (char)('a' + Random.Range(0, 26));
        // }
        commands.attack += words[Random.Range(0, words.Count - 1)];

        // Register Enemy object
        // TODO:

        return commands;
    }

    public
    void release(Enemy gameObject)
    {
        //todo:
    }

    public enum CommandType
    {
        Locate, Attack
    }

    // ------------------------------------------- Data << --==//

    // .............. Accessible from Unity's editor <<< ..--==//
    [SerializeField] public GameObject uiTextPrefab;

    // ============================ Private implementation < ==//
    // -------------------------------------- Behaviour << --==//
    // .............................. Initialization <<< ..--==//
    private void Awake()
    {
        locateSymbol = "";
        attackSymbol = "";
    }


    void Start()
    {
        words = new List<string> {"the",
"of",
"and",
"to",
"in",
"a",
"is",
"that",
"for",
"it",
"as",
"was",
"with",
"be",
"by",
"on",
"not",
"he",
"I",
"this",
"are",
"or",
"his",
"from",
"at",
"which",
"but",
"have",
"an",
"had",
"they",
"you",
"were",
"their",
"one",
"all",
"we",
"can",
"her",
"has",
"there",
"been",
"if",
"more",
"when",
"will",
"would",
"who",
"so",
"no",
"she",
"other",
"its",
"may",
"these",
"what",
"them",
"than",
"some",
"him",
"time",
"into",
"only",
"do",
"such",
"my",
"new",
"about",
"out",
"also",
"two",
"any",
"up",
"first",
"could",
"our",
"then",
"most",
"see",
"me",
"should",
"after",
"said",
"your",
"very",
"between",
"made",
"many",
"over",
"like",
"those",
"did",
"now",
"even",
"well",
"where",
"must",
"people",
"through",
"how",
"same",
"work",
"being",
"because",
"man",
"life",
"before",
"each",
"much",
"under",
"years",
"way",
"great",
"state",
"both",
"use",
"upon",
"own",
"used",
"however",
"us",
"part",
"good",
"world",
"make",
"three",
"while",
"long",
"day",
"without",
"just",
"men",
"general",
"during",
"another",
"little",
"found",
"here",
"system",
"does",
"de",
"down",
"number",
"case",
"against",
"might",
"still",
"back",
"right",
"know",
"place",
"every",
"government",
"too",
"high",
"old",
"different",
"states",
"take",
"year",
"power",
"since",
"given",
"god",
"never",
"social",
"order",
"water",
"thus",
"form",
"within",
"small",
"shall",
"public",
"large",
"law",
"come",
"less",
"children",
"war",
"point",
"called",
"American",
"again",
"often",
"go",
"few",
"among",
"important",
"end",
"get",
"house",
"second",
"though",
"present",
"example",
"himself",
"women",
"last",
"say",
"left",
"fact",
"off",
"set",
"per",
"yet",
"hand",
"came",
"development",
"thought",
"always",
"far",
"country",
"York",
"school",
"information",
"group",
"following",
"think",
"others",
"political",
"human",
"history",
"united",
"give",
"family",
"find",
"need",
"figure",
"possible",
"although",
"rather",
"later",
"university",
"once",
"course",
"until",
"several",
"national",
"whole",
"chapter",
"early",
"four",
"home",
"means",
"things",
"process",
"nature",
"above",
"therefore",
"having",
"certain",
"control",
"data",
"name",
"act",
"change",
"value",
"body",
"study",
"et",
"table",
"become",
"whether",
"city",
"book",
"taken",
"side",
"times",
"away",
"known",
"period",
"best",
"line",
"am",
"court",
"John",
"days",
"put",
"young",
"seen",
"common",
"person",
"either",
"let",
"why",
"land",
"head",
"business",
"company",
"church",
"words",
"effect",
"society",
"around",
"better",
"nothing",
"took",
"white",
"itself",
"something",
"light",
"question",
"almost",
"went",
"interest",
"mind",
"next",
"least",
"level",
"themselves",
"economic",
"child",
"death",
"service",
"view",
"action",
"five",
"II",
"press",
"father",
"further",
"love",
"research",
"area",
"true",
"education",
"self",
"age",
"necessary",
"subject",
"want",
"cases",
"ever",
"going",
"problem",
"free",
"done",
"making",
"party",
"king",
"together",
"century",
"section",
"using",
"position",
"type",
"result",
"help",
"individual",
"already",
"matter",
"full",
"half",
"various",
"sense",
"look",
"based",
"whose",
"English",
"south",
"total",
"class",
"became",
"perhaps",
"London",
"policy",
"members",
"al",
"local",
"enough",
"particular",
"rate",
"air",
"along",
"mother",
"knowledge",
"face",
"word",
"kind",
"open",
"terms",
"able",
"money",
"experience",
"conditions",
"support",
"la",
"problems",
"real",
"black",
"language",
"results",
"room",
"force",
"held",
"low",
"according",
"usually",
"north",
"show",
"night",
"told",
"short",
"field",
"reason",
"asked",
"quite",
"nor",
"health",
"special",
"thing",
"analysis",
"eyes",
"especially",
"lord",
"woman",
"major",
"similar",
"care",
"theory",
"brought",
"whom",
"office",
"art",
"production",
"sometimes",
"third",
"shown",
"British",
"due",
"international",
"began",
"single",
"natural",
"got",
"account",
"cause",
"community",
"saw",
"heart",
"soon",
"changes",
"studies",
"groups",
"method",
"evidence",
"seems",
"greater",
"required",
"trade",
"foreign",
"west",
"clear",
"model",
"near",
"students",
"probably",
"french",
"gave",
"including",
"read",
"England",
"material",
"term",
"past",
"report",
"considered",
"future",
"higher",
"structure",
"fig",
"available",
"working",
"felt",
"tell",
"amount",
"really",
"function",
"keep",
"indeed",
"growth",
"market",
"non",
"increase",
"personal",
"cost",
"mean",
"surface",
"knew",
"idea",
"lower",
"note",
"program",
"treatment",
"six",
"food",
"close",
"systems",
"blood",
"population",
"central",
"character",
"president",
"energy",
"property",
"living",
"provide",
"specific",
"science",
"return",
"practice",
"hands",
"role",
"countries",
"management",
"toward",
"son",
"says",
"generally",
"influence",
"purpose",
"America",
"received",
"strong",
"call",
"services",
"rights",
"current",
"believe",
"effects",
"letter",
"looked",
"story",
"forms",
"seemed",
"ground",
"main",
"paper",
"works",
"areas",
"modern",
"provided",
"moment",
"written",
"situation",
"turn",
"feet",
"plan",
"parts",
"values",
"movement",
"private",
"late",
"size",
"union",
"described",
"east",
"test",
"difficult",
"feel",
"river",
"poor",
"attention",
"books",
"town",
"space",
"price",
"turned",
"rule",
"percent",
"activity",
"across",
"play",
"building",
"anything",
"physical",
"capital",
"hard",
"makes",
"sea",
"cent",
"approach",
"pressure",
"finally",
"military",
"middle",
"sir",
"longer",
"spirit",
"continued",
"basis",
"army",
"red",
"alone",
"simple",
"below",
"series",
"source",
"increased",
"sent",
"particularly",
"earth",
"months",
"department",
"heard",
"questions",
"likely",
"lost",
"complete",
"behind",
"taking",
"wife",
"lines",
"object",
"hours",
"twenty",
"established",
"committee",
"related",
"range",
"truth",
"income",
"instead",
"beyond",
"rest",
"developed",
"outside",
"organization",
"religious",
"board",
"live",
"design",
"needs",
"persons",
"except",
"authority",
"patient",
"respect",
"latter",
"sure",
"culture",
"relationship",
"ten",
"methods",
"followed",
"William",
"condition",
"points",
"addition",
"direct",
"seem",
"industry",
"college",
"friends",
"beginning",
"hundred",
"manner",
"front",
"original",
"patients",
"appear",
"include",
"shows",
"ways",
"activities",
"relations",
"writing",
"council",
"disease",
"standard",
"fire",
"German",
"France",
"degree",
"towards",
"produced",
"leave",
"understand",
"cells",
"average",
"march",
"carried",
"length",
"difference",
"simply",
"normal",
"vol",
"quality",
"street",
"run",
"answer",
"morning",
"loss",
"doing",
"stage",
"pay",
"today",
"decision",
"labor",
"page",
"published",
"workers",
"bank",
"top",
"wanted",
"journal",
"passed",
"door",
"importance",
"western",
"tax",
"involved",
"solution",
"hope",
"voice",
"reading",
"obtained",
"bring",
"peace",
"needed",
"placed",
"chief",
"species",
"added",
"Europe",
"looking",
"factors",
"laws",
"behavior",
"die",
"response",
"led",
"association",
"performance",
"road",
"issue",
"consider",
"equal",
"learning",
"India",
"training",
"forces",
"cut",
"earlier",
"basic",
"member",
"friend",
"lead",
"appears",
"types",
"schools",
"music",
"James",
"temperature",
"christian",
"volume",
"kept",
"review",
"significant",
"former",
"meaning",
"associated",
"wrote",
"center",
"direction",
"everything",
"job",
"understanding",
"region",
"big",
"hold",
"opinion",
"text",
"June",
"date",
"application",
"author",
"cell",
"distribution",
"fall",
"becomes",
"Washington",
"limited",
"Indian",
"presence",
"sound",
"III",
"meeting",
"clearly",
"expected",
"federal",
"nearly",
"ed",
"extent",
"parents",
"yes",
"ideas",
"medical",
"observed",
"actually",
"final",
"George",
"miles",
"elements",
"list",
"project",
"product",
"throughout",
"Christ",
"discussion",
"applied",
"rules",
"produce",
"religion",
"deep",
"operation",
"issues",
"else",
"mass",
"coming",
"determined",
"European",
"events",
"security",
"oil",
"fine",
"distance",
"move",
"effective",
"paid",
"nation",
"step",
"gives",
"success",
"literature",
"products",
"neither",
"resources",
"follow",
"cross",
"ask",
"levels",
"immediately",
"certainly",
"principle",
"moral",
"July",
"formed",
"reached",
"faith",
"deal",
"recent",
"legal",
"administration",
"comes",
"materials",
"potential",
"presented",
"congress",
"civil",
"directly",
"meet",
"met",
"principles",
"expression",
"myself",
"born",
"wide",
"post",
"justice",
"strength",
"relation",
"statement",
"financial",
"dead",
"larger",
"cultural",
"historical",
"existence",
"built",
"weight",
"reference",
"feeling",
"round",
"reported",
"risk",
"appeared",
"included",
"scale",
"individuals",
"supply",
"million",
"differences",
"write",
"doubt",
"hour",
"industrial",
"April",
"primary",
"base",
"letters",
"interests",
"numbers",
"seven",
"places",
"wall",
"complex",
"entire",
"try",
"article",
"county",
"costs",
"thinking",
"record",
"flow",
"follows",
"sun",
"attempt",
"bad",
"instance",
"commission",
"easily",
"unit",
"died",
"green",
"Charles",
"week",
"demand",
"acid",
"environment",
"proper",
"takes",
"positive",
"talk",
"active",
"image",
"plant",
"freedom",
"library",
"dark",
"key",
"mentioned",
"co",
"speak",
"allowed",
"whatever",
"concerned",
"measure",
"lives",
"merely",
"fear",
"Paris",
"independent",
"heat",
"circumstances",
"Thomas",
"giving",
"master",
"tried",
"china",
"eye",
"upper",
"gone",
"actual",
"cold",
"frequently",
"eight",
"ability",
"unless",
"regard",
"henry",
"status",
"hear",
"thousand",
"minutes",
"parties",
"stock",
"student",
"rise",
"arms",
"factor",
"charge",
"easy",
"created",
"stand",
"started",
"content",
"share",
"picture",
"herself",
"agreement",
"remember",
"constant",
"none",
"popular",
"appropriate",
"style",
"start",
"goods"};
    }

    bool commandMode = false;

    void Update()
    {
        // if (Input.GetKey(locateSymbol)) {
        //     commandMode = true;
        // }

        // if ()
    }

    // ................................. Update loop <<< ..--==//

    // ------------------------------------------- Data << --==//
    public string locateSymbol = "";
    public string attackSymbol = "";

    // .................................. Components <<< ..--==//

    List<string> words;
}

// /////////////////////////////////////////////////////////// //