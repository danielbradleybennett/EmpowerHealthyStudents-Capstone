using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpowerHealthyStudents.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Blog = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPost_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    File = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    Grade = table.Column<string>(nullable: false),
                    FileType = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BlogPostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_BlogPost_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10000000-ffff-ffff-ffff-ffffffffffff", 0, "67ad88a7-d0ec-4b9d-a689-08bfb16748cf", "admin@admin.com", true, "April", true, "Crenshaw", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAECJphNcK4EsxPEARykMMjVY0y4Qx/c3Xp+P7PFu3X8/BApHEhwFS/7H7Y379l4lSCQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com" },
                    { "10000001-ffff-ffff-ffff-ffffffffffff", 0, "147ec19e-78df-49a8-8404-f849c1dbecd6", "karen@karen.com", true, "Karen", true, "Karen", false, null, "KAREN@KAREN.COM", "KAREN@KAREN.COM", null, null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "karen@karen.com" },
                    { "10000002-ffff-ffff-ffff-ffffffffffff", 0, "e772e266-7574-4f93-9be0-2310bb78dae0", "luke@luke.com", true, "Luke", true, "Luke", false, null, "LUKE@LUKE.COM", "  LUKE@LUKE.COM", null, null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "luke@luke.com" },
                    { "10000003-ffff-ffff-ffff-ffffffffffff", 0, "32fb23ea-52a5-4ed9-8f83-92425f0de40f", "seleste@seleste.com", true, "Seleste", true, "Seleste", false, null, "SELESTE@SELESTE.COM", "  SELESTE@SELESTE.COM", null, null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "seleste@seleste.com" }
                });

            migrationBuilder.InsertData(
                table: "BlogPost",
                columns: new[] { "Id", "Blog", "Date", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, @"Distance learning has now been in effect for several weeks, and I know many teachers who are struggling to maintain motivation.Let’s face it - it’s springtime, the weather is getting nicer, and it’s those last few weeks before school is over.If you’re anything like me, it’s hard to get motivated right now! Here are ten tips that I use daily to stay motivated during quarantine:
                1.	Maintain a daily schedule.Go to bed and get up at the same time each day and take scheduled breaks and lunch. 
                2.	Keep a To - Do List.Marking off items on a list helps me to keep going until the list is clear!
                3.	Connect with friends and family each day
                4.	Exercise for at least 30 minutes
                5.	Journal
                6.	Get enough sleep
                7.	Drinks LOTS of water
                8.	Avoid social media during “work” hours
                9.	Connect with other teachers
                10.	Give yourself some grace! 
                ", new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teaching in Quarantine. How Do I stay Motivated?", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, @"It takes a special soul to want to teach teenagers. How often have you heard, ""I'd never want to teach middle school!""?
                I personally love that age. Teenagers haven't yet figured out who they are, so if I can teach them something that empowers them, they grab onto it and transform before my very eyes. They are so full of energy and potential that, given a meaningful direction, they will launch themselves toward a goal or endeavor.

                How can I help my students self-regulate?
                First of all, recognize the amazing energy and potential in your students. Teenagers can tell if you really see them, rather than just look at them (or, worse, look through them). Until you can see the wonderful, flawed people before you, you can't effectively teach them.

                Once you connect with students, you can try these simple, free mini-lessons to help them gain strategies for self-regulation.

                •	Strategy 1: Teach students about their brains. Just as we help students understand how puberty changes their bodies, we should help them understand how it changes their minds. Teach ""Understanding the Parts of the Brain."" Then discuss how the reward center (the limbic system) is fully developed in the teenage brain, which is why teenagers experience emotion so profoundly. Afterward discuss how the prefrontal cortex is still rapidly developing—the spot that is transforming them from 13 year olds to adults.
                •	Strategy 2: Help students connect with their emotional centers. Instead of repressing students' feelings, we should recognize them and help students understand them. Teach ""Checking the Emotional Thermometer"" to give students a quick way to gauge the intensity of happiness, sadness, hurt, anger, love, or other feelings. Then discuss how feelings aren't right or wrong—they just are. The right or wrong part comes into play when people choose what to do with their feelings.
                •	Strategy 3: Teach the 5-5-5 breathing strategy. Given that emotions are more intense during the teenage years, students need strategies that help them manage stress, anxiety, anger, and other intense feelings. Teach ""Using 5-5-5 Breathing to Calm Down."" Afterward, ask students to share stories about situations in their day so far (or yesterday, if it's first hour), when they could have used such a strategy. Have them watch for situations that arise later in the day and try 5-5-5 breathing.
                •	Strategy 4: Promote positive self-talk. If a student is feeling bad, persistent negative thoughts can create a downward spiral. Help students recognize these thoughts, stop them, and replace them with positive thoughts—a first step in self-regulation. Teach ""Using Positive Self-Talk."" Discuss how this strategy helps break a negative fixed mindset and develop a positive growth mindset.
                •	Strategy 5: Help students set goals. Self-regulation begins in the moment, with recognizing moods and dealing with them appropriately. Self-regulation, however, can also grow into the future. Teach ""Setting and Reaching Goals."" Discuss how students can set goals in school and beyond. Ask them to think about who they want to become in one month, one year, and five years. Then ask them what doable steps they can take in the short term and long term to reach their goals.
                ", new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "5 Strategies to Help Your Students Self - Regulate", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, @"Some kids are ‘naturally’ more resilient than others. Straight off the bat, those with an optimistic personality will generally find change far more manageable than the more pessimistic among us. Luckily, there are lots of things we can do to nurture that natural resilience, or even create it from scratch, in our pessimists.

                1. Communicate openly and honestly
                Lots of parents try to keep the “harder” parts of life from their kids, even when they ask questions about things like money problems, marital disharmony, child abuse or other events they see in the media. While it’s tempting to shield our kids for as long as we possibly can, it makes sense to provide an open, honest answer that is appropriate to their age and personality.

                Being able to discuss the negative side of life helps them to understand that “bad things” happen, but it’s not the end of the world. Explaining things like, “sometimes people might have a fight even though they love each other very much. Just like you sometimes fight with your sister, and you still love her…” or “I don’t know why people do awful things to kids, but I do know that we do everything we possibly can to stop them.” Make sure you have lots of time available to answer all of their questions.

                2. Keep listening as they explore their feelings
                Believing that their parents (or other trusted adults) really value what they have to say and trust them to make their own decisions, is an important part of building resilience in kids, especially teens. We can all be a bit guilty of telling our kids how they should feel, rather than listening to how they really feel. We are so determined that they will love the world and all things in it, that we forget that life isn’t actually like that. “How fantastic is getting a B!” you squeal. Actually, Mum, I really wanted an A.

                Hard though it is, we’ve got to stop panicking when our kids feel bad and simply listen to the reason why. Many of us, on hearing a setback (this is me to a T), launch straight into “problem solving mode”. Rather than asking my kids how they think something should be fixed, I immediately start brainstorming ways I think things should be fixed.

                Remember, our job is not to solve our kids’ problems, our job is to show them that they are perfectly able to solve their own.

                3. Help them get to know what they’re “good at”
                Kids who think they are “good at” something are more willing to tackle new things and have a stronger sense of self. Remember, it doesn’t matter that you think they’re good at something, they need to agree!

                The best thing we can do is encourage them to have a go at just about anything that takes their fancy and see what “sticks”. Remind them that you don’t have to be “good at” something to enjoy it, and encourage them to keep on going if they really want something but are struggling to get there.

                Some kids find it hard to focus on the things they do well and others don’t actually value the things they can naturally do well. Help your child learn to value their assets by finding fantastic role models (real life, celebrities, historical figures, etc) to impress them with.

                If you still can’t convince them, help them set up a step-by-step approach to build skills in the area they are interested in. Focus on how valuable their ability to work hard to achieve their goals is – an incredible talent they will have for life.

                4. Make sure they know their wider family well
                Knowing they belong to an extended family – grandparents, aunts, uncles, cousins – is very important to most kids. Being a part of a large family and establishing their place within it is comforting for a kid of any age. Having many people in their life who care for them (almost!) as much as their parents provides a great sense of security and confidence. It also helps for them to have a family confidant when they no longer want their loving parents involved (hello, teens!).

                5. Engage with their school community
                While our kids no longer want to see our lovely faces at the school gate or canteen, they still get a sense of security knowing that we are part of things. There are of course many factors that influence how well our children do at school (both socially and academically), but here are three that matter a lot to most kids.
                •  They feel like they have something to contribute that is valuable
                This touches on what they consider they are “good at” (see above) and us helping them see the value of what they contribute. Often the most valuable contribution a person can make at school is to be a good friend and a good listener.
                •  They feel they have a connection with a particular teacher
                They will hopefully form a bond with a teacher, who may not even be their own. This teacher will generally have ‘extra time’ for them and cherish their individuality. They believe in them.
                •  They are involved
                Not every kid is a ‘joiner’, and certainly by high school there is a lot of resistance from some towards getting involved at school. But do press them to find ‘something’ that suits them.

                6. Get involved in the wider community
                Many families gain a sense of community through their religious group or being involved in a local club. For older kids, having relationships with adults and kids of all ages who are not part of their usual social or school group is an important way to build resilience. We all become fixed by the “roles” we play in life and tweens and teens are particularly vulnerable to this. At school the role of “clown” might already be taken, but at the Rugby club your son is known as the funny one.

                Often we forget the importance of “other people” in our kids’ lives. From a very young age our children have the potential to develop strong, nuturing relationships with people beyond their immediate family.

                7. Help them develop strong friendships
                It’s no surprise that having close friendships is an important way to build resilience. More than any other relationship, an adolescent “owns” their friendships. Family is just “there”, but a friendship is something they made all on their own. Friends remind us that we are accepted “just because we are us” and not because we are related or bound to be with someone. For this reason, even without the fun and support they offer, good friendships are vital for our general well being.

                8. Sharpen their self-compass
                A strong structure of core-beliefs about ourselves becomes an unbreakable foundation for self-worth, no matter what those beliefs are or where they come from. If we wholeheartedly believe something, then there are very few things that can happen that will shatter those beliefs.

                Obviously, we want our children’s compass to be full of positive, optimistic kinds of beliefs that foster an adaptable, pragmatic attitude towards external events. Rather than internalise everything that happens in life (“He’s not speaking to me, I must have done something wrong”), build resilience so you can hold fast to core beliefs and quickly externalize a situation (“He’s not speaking to me, but I haven’t done anything intentionally wrong, there must be something wrong with him today, I hope he’s okay, I’ll go and check in with him.”)

                9. Find a sport they love
                An ongoing commitment and mastery of some form of exercise is also a factor in determining how resilient a person is. Researchers have determined that the physical benefits and stress-relieving properties of high-intensity exercise contribute to overall brain health, which contributes to a person’s overall capability when challenged. No surprise here, of course. We’ve long known that daily exercise is one of the keys to a happy life.

                10. Practice mindfulness
                Mindfulness – particularly the ability to be with oneself – helps a child set their head in a ‘neutral’ position when faced with difficulties. In a neutral zone, we are neither positive nor negative, merely aware and reacting. 

                ", new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "How Parents Can Build Resilience in Adolescence", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, @"It’s no wonder that many high school students feel stressed. To a certain extent, this is normal and expected— everyone experiences stress, and many challenging and valuable experiences will also be unavoidably stressful. Stress can often be part of the experience of growth, and it’s not something you can or should totally avoid.
                  
                While feeling stressed in high school may be a natural response to a busy time in your life, you don’t have to resign yourself to its negative effects. There are ways to work on managing your stress that can help you to stay healthy as you pursue your dreams. Below, you’ll find a few of our favorite approaches for dealing with the stress of the high school experience.
                 
                 
                1.	Give yourself a break.
                Don’t feel bad about setting aside time in your life to do things that you enjoy and that make you happy, whether or not they seem “productive.” In fact, you should feel good about taking breaks—it’s an essential part of taking care of yourself. All of us need time to rest and refuel.
                 
                2.	Stay organized and create a good workspace.
                Cleaning your room, or otherwise organizing your spaces and belonging, can be an annoying task, and teenagers are notorious for the lengths they’ll go to to avoid tidying up. However, taking some time to keep things neat can pay off later in terms of stress relief.
                 
                 
                3.	Try some stereotypical relaxation activities.
                Lighting a candle, having a cup of tea, or taking a bubble bath may seem like cliched approaches to managing stress, but there’s a reason why these activities are so popular. First, they engage your senses, potentially providing a potent distraction from your worries. Second, they’re just plain enjoyable, making them particularly pleasant ways to take a break.
                 
                4.	Get outside and get moving.
                Getting outside, exercising, or participating in some other kind of physical activity can be a great distraction from stressful thoughts and tasks. Tiring yourself out physically can also help you to sleep better, and as we’ll discuss in greater detail below, quality sleep is a valuable thing.
                 
                5.	Develop better sleep habits. 
                Maintaining good sleep hygiene is hard. As a high school student, you don’t have a lot of control over your schedule— school starts at a certain time, extracurriculars and part-time jobs may dominate your after-school hours, and then there’s homework, a social life, and family obligations to juggle.

                6.	Finally, if you’re feeling seriously worried about your stress level, talking to a counselor, therapist, or other professional can really help. A professional’s education and experience allows them to provide you with specific tools, techniques, and insightful suggestions for how you can better manage your stress and look after your own well-being.
                ", new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 Tips for High School Students to Beat Stress", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, @"Initiative involves mobilizing and controlling motivation and attention. Many studies have shown that motivation depends on the alignment of many factors, such as understanding how to do an activity or feeling confident one can learn how. Initiative tends to be stronger if an individual is interested in the activity and in working with others.

                In everyday life, there are numerous factors that can impact the strength of motivation, especially the sustained motivation required to reach more challenging goals. In these situations, it’s possible for individuals, for youth in particular, to get overwhelmed, lose interest, or just get bored of the work. Schoolwork, close friends, or romantic relationships can also compete for their attention. For young people to stay focused and motivated many separate pieces need to come together to create a cohesive whole: the task for young people is to learn how to manage and arrange those pieces.

                In order to become an effective “doer,” youth must take action toward a goal and continue that effort over time to see that plan through. The abilities required include not just initiating effort toward a goal, but being able to regulate and sustain that effort through the challenges and setbacks that might be part of the journey.

                Research has long shown that motivation grows when people experience positive relationships, feel competent in what they are doing, and feel that what they are doing matters. Well-run youth programs are rich learning contexts for youth to gain the experiences, skills, and dispositions for initiative. Staff play important roles in providing structures that help youth identify difficult personal goals that motivate their projects, and then staff help as needed to allow youth to experience success in persevering and working toward them.

                ", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Importance of Initiative for Students", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 6, @"The mental health of nearly 5 million kids is neglected on a daily basis.

                Of the roughly 50 million children in public school at any given time, upwards of 20% -- that's 5 million kids -- are showing signs of a mental health disorder. A vast majority aren't receiving any help from the school in the form of therapy or counseling, which raises the question: How can this situation be improved?

                The mental health crisis in our schools is a result of a lack of education on the matter, and a lack of resources to properly mitigate it. Teachers, who are the most hands-on with these students the majority of the time, aren't trained in mental health. And on top of that, they have 25+ other students in that class and dozens of other responsibilities on their plate. They are not equipped with the time, resources, or training necessary to give students with signs of mental health issues the unique attention they deserve. Moreover, mental health education is seldom part of the student’s curriculum, even though parents recognize the importance of the subject.

                And then there are the school counselors. With each counselor responsible for an average of 500 students, the chances of them recognizing symptoms of mental health issues in a portion of those students are slim. They are also employed to focus primarily on academics, so unless this student is seeing them on a regular basis for matters of academia, the counselor is unlikely to notice changes in behavior or attitude that would signify an underlying disorder.

                A school psychologist would be ideal, but it's rare that public schools have full-time specialists in this field on staff.

                So what can be done? And why is it so important that this issue be brought to light?

                Children with mental health issues often have the odds of success stacked against them. Often these ailments negatively affect their ability to learn, or at least their ability to learn at the same pace or in the same way as most of the other students in their classes. These mental health ailments can cause them to feel uncomfortable in classroom settings, discouraging them from speaking up or participating, and even causing them to have a harder time building relationships with others. Their mental health issues can be an upsetting distraction, contributing to their feelings of isolation and loneliness. Many children in this situation feel like no one understand them or is looking out for them.

                Teachers are the people most likely to recognize the sign in their students, but if they don't have the time or education to properly approach the situation and cater specifically to the needs of that student, then how can they help once they pick up on a problem? A very simple way to open the door to a healthier education for these students would be for the teacher to approach the child directly, asking how they're feeling or if they need help with anything. If no one is asking the children if something is wrong, it'll be a rare occasion that the child opens up to anyone about it. Something as simple as this conversation could increase their drive to do well in school, while also giving them the space to talk about what's bothering them.

                The National Association on Mental Illness reports that half of all chronic mental illness begins by 14 years of age. It's imperative to identify and address it as early as possible, and school staff is in the perfect position to identify early signs of mental illness. If teachers are encouraged by the school districts and administrators to pay attention to the mental health of their students, and given a clear course of action to get the child help, then perhaps we can work toward a more safe and stable educational environment for these children.

                With all eyes paying attention, from home to school and back home again, there is a strong promise of a better tomorrow for children in our public schools. After all, it takes a village.", new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Is mental health neglected in our children’s schools?", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 7, @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Feugiat nisl pretium fusce id. Maecenas pharetra convallis posuere morbi leo urna molestie. Amet commodo nulla facilisi nullam. Volutpat diam ut venenatis tellus. Pellentesque elit ullamcorper dignissim cras tincidunt lobortis. Quis auctor elit sed vulputate mi. Condimentum id venenatis a condimentum vitae sapien. Aliquet porttitor lacus luctus accumsan tortor. Nisl purus in mollis nunc sed id. Penatibus et magnis dis parturient montes nascetur ridiculus. Quis blandit turpis cursus in hac habitasse. Vitae congue eu consequat ac felis donec. Pulvinar mattis nunc sed blandit libero.

                Egestas integer eget aliquet nibh praesent tristique. Tempus egestas sed sed risus pretium quam. Morbi leo urna molestie at elementum. Nibh praesent tristique magna sit amet purus gravida quis. Porta nibh venenatis cras sed felis eget velit. Phasellus vestibulum lorem sed risus. Proin libero nunc consequat interdum varius sit. Eu ultrices vitae auctor eu augue ut lectus. Nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus. Ut ornare lectus sit amet. Sem nulla pharetra diam sit amet nisl suscipit adipiscing. Lacus sed viverra tellus in hac habitasse platea. Sit amet dictum sit amet justo donec enim diam vulputate. Pharetra pharetra massa massa ultricies mi quis hendrerit dolor. Ut tristique et egestas quis ipsum. Mattis nunc sed blandit libero volutpat sed cras ornare. Nulla pellentesque dignissim enim sit amet venenatis.

                Nunc eget lorem dolor sed viverra. Mi eget mauris pharetra et. Porta nibh venenatis cras sed felis. Convallis posuere morbi leo urna. Pulvinar sapien et ligula ullamcorper malesuada proin libero nunc. Neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing. Blandit turpis cursus in hac. Imperdiet proin fermentum leo vel orci. Turpis tincidunt id aliquet risus feugiat in ante metus. Nisl rhoncus mattis rhoncus urna. Dictum sit amet justo donec enim. Purus in mollis nunc sed id semper risus in.

                Eget mi proin sed libero enim sed faucibus. Volutpat commodo sed egestas egestas fringilla. Elementum pulvinar etiam non quam lacus suspendisse. Volutpat lacus laoreet non curabitur gravida. Morbi tristique senectus et netus. Vestibulum sed arcu non odio euismod. Non quam lacus suspendisse faucibus interdum posuere lorem ipsum. Non curabitur gravida arcu ac tortor dignissim. Lectus sit amet est placerat in egestas. Porttitor eget dolor morbi non arcu risus quis. Curabitur vitae nunc sed velit dignissim sodales ut. Convallis convallis tellus id interdum velit laoreet id donec ultrices. Nisl pretium fusce id velit ut.
                ", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tips for Coping with Depression", "10000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Date", "Location", "UserId" },
                values: new object[,]
                {
                    { 7, new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Educator Conference: Chicago, Illinois", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 6, new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secondary SEL Seminar: Seatle, Washington", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, new DateTime(2020, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Literacy and SEL Seminar: Nashville, Tennessee", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher Creator Conference: Cleveland, Orlando", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professinal Development Seminar: Atlanta, Georgia", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 1, new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEL Teacher Conference: Phoenix, Arizona", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "High School Leadership Conference: Orlando, FLorida", "10000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "File", "FileType", "Grade", "Image", "Name", "Subject", "UserId" },
                values: new object[,]
                {
                    { 9, @"In this post-reading activity for Shakespeare's Hamlet, the students will roleplay as different characters. They will be pitted against each other and attempt to defend their character's right to exist within the play. After each smackdown match-up, the class will vote on who does a better job of defending themselves. The winner will move on to the next round. The process will be completed until there is only one student left standing. Feel free to crate a championship belt for the winner of this activity!

                Note: You will need to provide slips of paper with character names.
                ", null, "Presentation(Powerpoint) File", "7th, 8th, 9th, 10th, 11th, 12th", null, "Hamlet Character Smackdown: Roleplay Lesson", "Reading, Literature", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 1, @"This guided handout allows adolescents to identify the unhealthy coping skills they use when their emotions are overwhelming and to choose from 50 healthy coping skills instead!

                This resource features:
                •	Reflection of unhealthy coping skills and consequences
                •	DBT and CBT-based coping skills (distraction, self-soothing, mindfulness, emotion regulation, identifying cognitive distortions, distraction)
                •	3 custom spots for individualized coping skills
                •	Reflection of how these skills may be helpful
                •	Space for signature and date

                Perfect for school counselors, social workers, or therapists to help students reflect on their behavior, choose new coping skills, and reflect on why the chosen skills can help! It could also be used as a contract for behavior improvement.

                Keep on file, update during each session, and use alongside CBT and DBT!
                ", "Mind_flayer.jpg", "PDF", "9th, 10th, 11th, 12th", "Mind_flayer.jpg", "Making Healthy Choices: Coping Skill Worksheet For Adolescents", "School Counseling, Character Education", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, @"This product contains one powerpoint presentation with ten journal prompts to get students thinking about resilience.Could be used for bell ringer activities, within dedicated SEL time, or individually.

                Includes BONUS ""Additional Resources"" pages with articles, websites, and literature that discuss conflict.", null, "PowerPoint", "8th, 9th, 10th, 11th, 12th", null, "Social Emotional Learning Journal Prompts Unit 2: Conflict", "School Counseling, Character Education", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, @"-Customizable in Powerpoint

                This literary element project is a post-reading exploration of characterization, conflict, fable, satire, foreshadowing, symbolism, irony, and propaganda within the novel Animal Farm by George Orwell. Students will complete various activities that improve comprehension of the novel as well as analysis of major literary elements. Graphic organizers and creative responses, including writing an original fable, help keep student interest high as they learn more about this important novel.

                This project was originally designed for an English II Standard and Inclusion class, but will work great for students at any level.

                Please note that there is no rubric for this resource.", null, "PowerPoint", "7th, 8th, 9th, 10th, 11th, 12th", null, "Animal Farm Literary Elements Project", "Literature", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, @"This product contains one powerpoint presentation with ten journal prompts to get students thinking about resilience. Could be used for bell ringer activities, within dedicated SEL time, or individually.

                Includes BONUS ""Additional Resources"" pages with articles, websites, and literature that discuss resilience.", null, "Presentation (Powerpoint) File", "9th, 10th, 11th, 12th", null, "Social Emotional Learning Journal Prompts Unit 1: Resilience", "Life Skills, Character Education, School Psychology", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, @"50 unique positive affirmation coloring pages! These affirmations focus on choice, behavior, positivity, challenges, hope, and resilience. Each affirmation was written by me and are in standard 8.5x11 paper.

                Students can decorate and color these pages, and would look great as classroom art. They can also be used as a mindfulness or calming practice!", null, "Presentation (Powerpoint) File", "7th, 8th, 9th, 10th, 11th, 12th", null, "50 Positive Affirmation Coloring Pages", "School Counseling, Character Education", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 6, @"The English ""Best Friend"" is a cheat sheet for your students to keep all year. It features commonly confused words, a list of words to use instead of ""said"", how to be concise in academic writing, errors in construction notes, common logical fallacies, literary terms and definitions, and more! It includes two text boxes reserved for specific information relating to your class or school.

                I printed these on brightly colored paper and named them after cartoon and literary characters, and we had an ""adoption"" ceremony at the beginning of the year. I allow my students to use these on any test!

                This is a two page document. The file name reads ""English IV"" but it's great for any level 7th-12th.", null, "Word Document File", "7th, 8th, 9th, 10th, 11th, 12th", null, "English Best Friend Cheat Sheet", "English, Literature, Writing", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 7, @"-Now in PowerPoint form

                -Fully customizable

                -Now with sample rubric

                -Resource in black and white for easy printing and distribution

                Student choice is featured in this post-reading cumulative project for the book 1984 by George Orwell. Students choose from over 20 activities of various point values in order to get 100 points. Multiple intelligences are recognized within the activities, which range from creative writing to graphic design.

                This project was originally designed for an English IV standard and inclusion class, but may be adapted for higher levels.", null, "Presentation (Powerpoint) File", "7th, 8th, 9th, 10th, 11th, 12th", null, "1984 100 Point Project", "Literature", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 8, "In this post-reading activity for Shakespeare's Hamlet, the student will create an epithet for one of the (many) dead characters. This activity reinforces comprehension and students have fun choosing symbols and quotes to draw on the picture of the grave.", null, "Word Document File", "7th, 8th, 9th, 10th, 11th, 12th", null, "Hamlet Character Epithet", "Reading, Literature", "10000000-ffff-ffff-ffff-ffffffffffff" },
                    { 10, "These ten tips come in a .pdf format and can be printed as a poster in your classroom, given to students, or displayed on a screen!", null, "PDF", "5th, 6th, 7th, 8th, 9th, 10th, 11th, 12th", null, "Ten Tips to Build Your Resilience", "Character Education", "10000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "BlogPostId", "Date", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "You are a Godsend.", "10000001-ffff-ffff-ffff-ffffffffffff" },
                    { 2, 1, new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thank you for this advice.", "10000001-ffff-ffff-ffff-ffffffffffff" },
                    { 3, 1, new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is great stuff.", "10000001-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "ProductReview",
                columns: new[] { "Id", "Comment", "Date", "ProductId", "UserId" },
                values: new object[] { 1, "This is so inspiring.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "10000001-ffff-ffff-ffff-ffffffffffff" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_UserId",
                table: "BlogPost",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BlogPostId",
                table: "Comment",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserId",
                table: "Event",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_UserId",
                table: "ProductReview",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
