using System;
using System.Collections.Generic;
using System.Text;
using EmpowerHealthyStudents.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using EmpowerHealthyStudents.Models.ViewModels;
using System.ComponentModel;
using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;

namespace EmpowerHealthyStudents.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<BlogPost> BlogPost { get; set; }

        public DbSet<ProductReview> ProductReview { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            //modelBuilder.Entity<Comment>()
            //    .HasMany(c => c.BlogComment)
            //    .WithOne(l => l.Comment)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.OrderProducts)
            //    .WithOne(l => l.Order)
            //    .OnDelete(DeleteBehavior.Restrict);


            ApplicationUser user = new ApplicationUser
            {
                FirstName = "April",
                LastName = "Crenshaw",
                UserName = "admin@admin.com",
                IsAdmin = true,
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "10000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser user1 = new ApplicationUser
            {
                FirstName = "Karen",
                LastName = "Karen",
                UserName = "karen@karen.com",
                IsAdmin = true,
                NormalizedUserName = "KAREN@KAREN.COM",
                Email = "karen@karen.com",
                NormalizedEmail = "KAREN@KAREN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "10000001-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash1 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash1.HashPassword(user1, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user1);

            ApplicationUser user2 = new ApplicationUser
            {
                FirstName = "Luke",
                LastName = "Luke",
                UserName = "luke@luke.com",
                IsAdmin = true,
                NormalizedUserName = "  LUKE@LUKE.COM",
                Email = "luke@luke.com",
                NormalizedEmail = "LUKE@LUKE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "10000002-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash2.HashPassword(user2, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            ApplicationUser user3 = new ApplicationUser
            {
                FirstName = "Seleste",
                LastName = "Seleste",
                UserName = "seleste@seleste.com",
                IsAdmin = true,
                NormalizedUserName = "  SELESTE@SELESTE.COM",
                Email = "seleste@seleste.com",
                NormalizedEmail = "SELESTE@SELESTE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "10000003-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash3 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash3.HashPassword(user3, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user3);

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Making Healthy Choices: Coping Skill Worksheet For Adolescents",
                    Description = "This guided handout allows adolescents to identify the unhealthy coping skills they use when their emotions are overwhelming and to choose from 50 healthy coping skills instead!\n\nThis resource features:\n•\tReflection of unhealthy coping skills and consequences\n•\tDBT and CBT-based coping skills (distraction, self-soothing, mindfulness, emotion regulation, identifying cognitive distortions, distraction)\n•\t3 custom spots for individualized coping skills\n•\tReflection of how these skills may be helpful\n•\tSpace for signature and date\n\nPerfect for school counselors, social workers, or therapists to help students reflect on their behavior, choose new coping skills, and reflect on why the chosen skills can help! It could also be used as a contract for behavior improvement.\n\nKeep on file, update during each session, and use alongside CBT and DBT!\n",
                    UserId = user.Id,
                    File = "Making Healthy Choices.pdf",
                    Image = "CopingSkill.jpg",
                    Grade = "9th, 10th, 11th, 12th",
                    Subject = "School Counseling, Character Education",
                    FileType = "PDF"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Social Emotional Learning Journal Prompts Unit 2: Conflict",
                    Description = "This product contains one powerpoint presentation with ten journal prompts to get students thinking about resilience.Could be used for bell ringer activities, within dedicated SEL time, or individually.\n\nIncludes BONUS \"Additional Resources\" pages with articles, websites, and literature that discuss conflict.",
                    UserId = user.Id,
                    Grade = "8th, 9th, 10th, 11th, 12th",
                    Subject = "School Counseling, Character Education",
                    FileType = "PowerPoint",
                    Image = "10JournalPrompts2.jpg",
                    File = "SEL Journal Prompts Unit 2 Conflict.pptx",

                },
                new Product()
                {
                    Id = 3,
                    Name = "Animal Farm Literary Elements Project",
                    Description = "-Customizable in Powerpoint\n\nThis literary element project is a post-reading exploration of characterization, conflict, fable, satire, foreshadowing, symbolism, irony, and propaganda within the novel Animal Farm by George Orwell. Students will complete various activities that improve comprehension of the novel as well as analysis of major literary elements. Graphic organizers and creative responses, including writing an original fable, help keep student interest high as they learn more about this important novel.\n\nThis project was originally designed for an English II Standard and Inclusion class, but will work great for students at any level.\n\nPlease note that there is no rubric for this resource.",
                    UserId = user.Id,
                    Grade = "7th, 8th, 9th, 10th, 11th, 12th",
                    Subject = "Literature",
                    FileType = "PowerPoint",
                    Image = "AnimalFarm.jpg",
                    File = "AnimalFarmLiteraryElementsProject(1).docx",
                },
                new Product()
                {
                    Id = 4,
                    Name = "Social Emotional Learning Journal Prompts Unit 1: Resilience",
                    Description = "This product contains one powerpoint presentation with ten journal prompts to get students thinking about resilience. Could be used for bell ringer activities, within dedicated SEL time, or individually.\n\nIncludes BONUS \"Additional Resources\" pages with articles, websites, and literature that discuss resilience.",
                    UserId = user.Id,
                    Grade = "9th, 10th, 11th, 12th",
                    Subject = "Life Skills, Character Education, School Psychology",
                    FileType = "Presentation (Powerpoint) File",
                    Image = "10SocialEmotionalLearningJournalPrompts.jpg",
                    File = "SEL Journal Prompts Unit 1 Resilience.pptx"
                },
                new Product()
                {
                    Id = 5,
                    Name = "50 Positive Affirmation Coloring Pages",
                    Description = "50 unique positive affirmation coloring pages! These affirmations focus on choice, behavior, positivity, challenges, hope, and resilience. Each affirmation was written by me and are in standard 8.5x11 paper.\n\nStudents can decorate and color these pages, and would look great as classroom art. They can also be used as a mindfulness or calming practice!",
                    UserId = user.Id,
                    Grade = "7th, 8th, 9th, 10th, 11th, 12th",
                    Subject = "School Counseling, Character Education",
                    FileType = "Presentation (Powerpoint) File",
                    Image = "50 positive affirmation coloring pages.jpg",
                    File = "EmpowerHealthPositive Affirmation Coloring Pages Thumbnail(1).pptx"
                },
                 new Product()
                 {
                    Id = 6,
                    Name = "English Best Friend Cheat Sheet",
                    Description = "The English \"Best Friend\" is a cheat sheet for your students to keep all year. It features commonly confused words, a list of words to use instead of \"said\", how to be concise in academic writing, errors in construction notes, common logical fallacies, literary terms and definitions, and more! It includes two text boxes reserved for specific information relating to your class or school.\n\nI printed these on brightly colored paper and named them after cartoon and literary characters, and we had an \"adoption\" ceremony at the beginning of the year. I allow my students to use these on any test!\n\nThis is a two page document. The file name reads \"English IV\" but it's great for any level 7th-12th.",
                    UserId = user.Id,
                    Grade = "7th, 8th, 9th, 10th, 11th, 12th",
                    Subject = "English, Literature, Writing",
                    FileType = "Word Document File",
                    Image = "LogoMakr_0Vw3E3.png",
                    File = "EnglishBestFriendCheatSheet(1).docx"
                 },
                 new Product()
                 {
                     Id = 7,
                     Name = "1984 100 Point Project",
                    Description = "-Now in PowerPoint form\n\n-Fully customizable\n\n-Now with sample rubric\n\n-Resource in black and white for easy printing and distribution\n\nStudent choice is featured in this post-reading cumulative project for the book 1984 by George Orwell. Students choose from over 20 activities of various point values in order to get 100 points. Multiple intelligences are recognized within the activities, which range from creative writing to graphic design.\n\nThis project was originally designed for an English IV standard and inclusion class, but may be adapted for higher levels.",
                     UserId = user.Id,
                     Grade = "7th, 8th, 9th, 10th, 11th, 12th",
                    Subject = "Literature",
                    FileType = "Presentation (Powerpoint) File",
                    Image = "1984.jpg",
                    File = "1984100PointProject.doc"
                 },
                 new Product()
                 {
                     Id = 8,
                     Name = "Hamlet Character Epithet",
                     Description = "In this post-reading activity for Shakespeare's Hamlet, the student will create an epithet for one of the (many) dead characters. This activity reinforces comprehension and students have fun choosing symbols and quotes to draw on the picture of the grave.",
                     UserId = user.Id,
                     Grade = "7th, 8th, 9th, 10th, 11th, 12th",
                     Subject = "Reading, Literature",
                     FileType = "Word Document File",
                     Image = "LogoMakr_0Vw3E3.png",
                     File = "HamletCharacterEpithet(1).docx"
                 },
                 new Product()
                 {
                     Id = 9,
                     Name = "Hamlet Character Smackdown: Roleplay Lesson",
                     Description = "In this post-reading activity for Shakespeare's Hamlet, the students will roleplay as different characters. They will be pitted against each other and attempt to defend their character's right to exist within the play. After each smackdown match-up, the class will vote on who does a better job of defending themselves. The winner will move on to the next round. The process will be completed until there is only one student left standing. Feel free to crate a championship belt for the winner of this activity!\n\nNote: You will need to provide slips of paper with character names.\n",
                     UserId = user.Id,
                     Grade = "7th, 8th, 9th, 10th, 11th, 12th",
                     Subject = "Reading, Literature",
                     FileType = "Presentation(Powerpoint) File",
                     Image = "LogoMakr_0Vw3E3.png",
                     File = "HamletCharacterSmackdownRoleplayLesson(1)(1).ppt"
                 },
                 new Product()
                 {
                     Id = 10,
                     Name = "Ten Tips to Build Your Resilience",
                     Description = "These ten tips come in a .pdf format and can be printed as a poster in your classroom, given to students, or displayed on a screen!",
                     UserId = user.Id,
                     Grade = "5th, 6th, 7th, 8th, 9th, 10th, 11th, 12th",
                     Subject = "Character Education",
                     FileType = "PDF",
                     Image = "LogoMakr_0Vw3E3.png",
                     File = "10 Tips to Build Resilience.pdf"

                 });
            modelBuilder.Entity<Event>().HasData(
                new Event()
                {
                    Id = 1,
                    Location = "SEL Teacher Conference: Phoenix, Arizona",
                    Date = DateTime.Parse("06/20/2020"),
                    UserId = user.Id
                   

                },
                new Event()
                {
                    Id = 2,
                    Location = "Professinal Development Seminar: Atlanta, Georgia",
                    Date = DateTime.Parse("06/23/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 3,
                    Location = "High School Leadership Conference: Orlando, FLorida",
                    Date = DateTime.Parse("07/11/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 4,
                    Location = "Literacy and SEL Seminar: Nashville, Tennessee",
                    Date = DateTime.Parse("07/24/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 5,
                    Location = "Teacher Creator Conference: Cleveland, Orlando",
                    Date = DateTime.Parse("06/23/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 6,
                    Location = "Secondary SEL Seminar: Seatle, Washington",
                    Date = DateTime.Parse("08/12/2020"),
                    UserId = user.Id

                },
                new Event()
                {
                    Id = 7,
                    Location = "National Educator Conference: Chicago, Illinois",
                    Date = DateTime.Parse("06/23/2020"),
                    UserId = user.Id

                });

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost()
                {
                    Id = 1,
                    Title = "Teaching in Quarantine. How Do I stay Motivated?",
                    Blog = "Teaching In Quarantine: How Do I Stay Motivated ?\nDistance learning has now been in effect for several weeks, and I know many teachers who are struggling to maintain motivation. Let’s face it - it’s springtime, the weather is getting nicer, and it’s those last few weeks before school is over. If you’re anything like me, it’s hard to get motivated right now! Here are ten tips that I use daily to stay motivated during quarantine:\n\n1.\tMaintain a daily schedule.Go to bed and get up at the same time each day and take scheduled breaks and lunch. \n2.\tKeep a To - Do List.Marking off items on a list helps me to keep going until the list is clear!\n3.\tConnect with friends and family each day\n4.\tExercise for at least 30 minutes\n5.\tJournal\n6.\tGet enough sleep\n7.\tDrinks LOTS of water\n8.\tAvoid social media during “work” hours\n9.\tConnect with other teachers\n10.\tGive yourself some grace! \n",                    
                    UserId = user.Id,
                    Date = DateTime.Parse("04/11/2020")
                },
                new BlogPost()
                {
                    Id = 2, 
                    Title = "5 Strategies to Help Your Students Self - Regulate",
                    Blog = "It takes a special soul to want to teach teenagers. How often have you heard, \"I'd never want to teach middle school!\"?\nI personally love that age. Teenagers haven't yet figured out who they are, so if I can teach them something that empowers them, they grab onto it and transform before my very eyes. They are so full of energy and potential that, given a meaningful direction, they will launch themselves toward a goal or endeavor.\n\nHow can I help my students self-regulate?\nFirst of all, recognize the amazing energy and potential in your students. Teenagers can tell if you really see them, rather than just look at them (or, worse, look through them). Until you can see the wonderful, flawed people before you, you can't effectively teach them.\n\nOnce you connect with students, you can try these simple, free mini-lessons to help them gain strategies for self-regulation.\n\n•\tStrategy 1: Teach students about their brains. Just as we help students understand how puberty changes their bodies, we should help them understand how it changes their minds. Teach \"Understanding the Parts of the Brain.\" Then discuss how the reward center (the limbic system) is fully developed in the teenage brain, which is why teenagers experience emotion so profoundly. Afterward discuss how the prefrontal cortex is still rapidly developing—the spot that is transforming them from 13 year olds to adults.\n\n•\tStrategy 2: Help students connect with their emotional centers. Instead of repressing students' feelings, we should recognize them and help students understand them. Teach \"Checking the Emotional Thermometer\" to give students a quick way to gauge the intensity of happiness, sadness, hurt, anger, love, or other feelings. Then discuss how feelings aren't right or wrong—they just are. The right or wrong part comes into play when people choose what to do with their feelings.\n\n•\tStrategy 3: Teach the 5-5-5 breathing strategy. Given that emotions are more intense during the teenage years, students need strategies that help them manage stress, anxiety, anger, and other intense feelings. Teach \"Using 5-5-5 Breathing to Calm Down.\" Afterward, ask students to share stories about situations in their day so far (or yesterday, if it's first hour), when they could have used such a strategy. Have them watch for situations that arise later in the day and try 5-5-5 breathing.\n\n•\tStrategy 4: Promote positive self-talk. If a student is feeling bad, persistent negative thoughts can create a downward spiral. Help students recognize these thoughts, stop them, and replace them with positive thoughts—a first step in self-regulation. Teach \"Using Positive Self-Talk.\" Discuss how this strategy helps break a negative fixed mindset and develop a positive growth mindset.\n\n•\tStrategy 5: Help students set goals. Self-regulation begins in the moment, with recognizing moods and dealing with them appropriately. Self-regulation, however, can also grow into the future. Teach \"Setting and Reaching Goals.\" Discuss how students can set goals in school and beyond. Ask them to think about who they want to become in one month, one year, and five years. Then ask them what doable steps they can take in the short term and long term to reach their goals.\n",
                    UserId = user.Id,
                    Date = DateTime.Parse("04/15/2020")
                },
                new BlogPost()
                {
                    Id = 3,
                    Title = "How Parents Can Build Resilience in Adolescence",
                    Blog = "Some kids are ‘naturally’ more resilient than others. Straight off the bat, those with an optimistic personality will generally find change far more manageable than the more pessimistic among us. Luckily, there are lots of things we can do to nurture that natural resilience, or even create it from scratch, in our pessimists.\n\n1. Communicate openly and honestly\nLots of parents try to keep the “harder” parts of life from their kids, even when they ask questions about things like money problems, marital disharmony, child abuse or other events they see in the media. While it’s tempting to shield our kids for as long as we possibly can, it makes sense to provide an open, honest answer that is appropriate to their age and personality.\n\nBeing able to discuss the negative side of life helps them to understand that “bad things” happen, but it’s not the end of the world. Explaining things like, “sometimes people might have a fight even though they love each other very much. Just like you sometimes fight with your sister, and you still love her…” or “I don’t know why people do awful things to kids, but I do know that we do everything we possibly can to stop them.” Make sure you have lots of time available to answer all of their questions.\n\n2. Keep listening as they explore their feelings\nBelieving that their parents (or other trusted adults) really value what they have to say and trust them to make their own decisions, is an important part of building resilience in kids, especially teens. We can all be a bit guilty of telling our kids how they should feel, rather than listening to how they really feel. We are so determined that they will love the world and all things in it, that we forget that life isn’t actually like that. “How fantastic is getting a B!” you squeal. Actually, Mum, I really wanted an A.\n\nHard though it is, we’ve got to stop panicking when our kids feel bad and simply listen to the reason why. Many of us, on hearing a setback (this is me to a T), launch straight into “problem solving mode”. Rather than asking my kids how they think something should be fixed, I immediately start brainstorming ways I think things should be fixed.\n\nRemember, our job is not to solve our kids’ problems, our job is to show them that they are perfectly able to solve their own.\n\n3. Help them get to know what they’re “good at”\nKids who think they are “good at” something are more willing to tackle new things and have a stronger sense of self. Remember, it doesn’t matter that you think they’re good at something, they need to agree!\n\nThe best thing we can do is encourage them to have a go at just about anything that takes their fancy and see what “sticks”. Remind them that you don’t have to be “good at” something to enjoy it, and encourage them to keep on going if they really want something but are struggling to get there.\n\nSome kids find it hard to focus on the things they do well and others don’t actually value the things they can naturally do well. Help your child learn to value their assets by finding fantastic role models (real life, celebrities, historical figures, etc) to impress them with.\n\nIf you still can’t convince them, help them set up a step-by-step approach to build skills in the area they are interested in. Focus on how valuable their ability to work hard to achieve their goals is – an incredible talent they will have for life.\n\n4. Make sure they know their wider family well\nKnowing they belong to an extended family – grandparents, aunts, uncles, cousins – is very important to most kids. Being a part of a large family and establishing their place within it is comforting for a kid of any age. Having many people in their life who care for them (almost!) as much as their parents provides a great sense of security and confidence. It also helps for them to have a family confidant when they no longer want their loving parents involved (hello, teens!).\n\n5. Engage with their school community\nWhile our kids no longer want to see our lovely faces at the school gate or canteen, they still get a sense of security knowing that we are part of things. There are of course many factors that influence how well our children do at school (both socially and academically), but here are three that matter a lot to most kids.\n•  They feel like they have something to contribute that is valuable\nThis touches on what they consider they are “good at” (see above) and us helping them see the value of what they contribute. Often the most valuable contribution a person can make at school is to be a good friend and a good listener.\n•  They feel they have a connection with a particular teacher\nThey will hopefully form a bond with a teacher, who may not even be their own. This teacher will generally have ‘extra time’ for them and cherish their individuality. They believe in them.\n•  They are involved\nNot every kid is a ‘joiner’, and certainly by high school there is a lot of resistance from some towards getting involved at school. But do press them to find ‘something’ that suits them.\n\n6. Get involved in the wider community\nMany families gain a sense of community through their religious group or being involved in a local club. For older kids, having relationships with adults and kids of all ages who are not part of their usual social or school group is an important way to build resilience. We all become fixed by the “roles” we play in life and tweens and teens are particularly vulnerable to this. At school the role of “clown” might already be taken, but at the Rugby club your son is known as the funny one.\n\nOften we forget the importance of “other people” in our kids’ lives. From a very young age our children have the potential to develop strong, nuturing relationships with people beyond their immediate family.\n\n7. Help them develop strong friendships\nIt’s no surprise that having close friendships is an important way to build resilience. More than any other relationship, an adolescent “owns” their friendships. Family is just “there”, but a friendship is something they made all on their own. Friends remind us that we are accepted “just because we are us” and not because we are related or bound to be with someone. For this reason, even without the fun and support they offer, good friendships are vital for our general well being.\n\n8. Sharpen their self-compass\nA strong structure of core-beliefs about ourselves becomes an unbreakable foundation for self-worth, no matter what those beliefs are or where they come from. If we wholeheartedly believe something, then there are very few things that can happen that will shatter those beliefs.\n\nObviously, we want our children’s compass to be full of positive, optimistic kinds of beliefs that foster an adaptable, pragmatic attitude towards external events. Rather than internalise everything that happens in life (“He’s not speaking to me, I must have done something wrong”), build resilience so you can hold fast to core beliefs and quickly externalize a situation (“He’s not speaking to me, but I haven’t done anything intentionally wrong, there must be something wrong with him today, I hope he’s okay, I’ll go and check in with him.”)\n\n9. Find a sport they love\nAn ongoing commitment and mastery of some form of exercise is also a factor in determining how resilient a person is. Researchers have determined that the physical benefits and stress-relieving properties of high-intensity exercise contribute to overall brain health, which contributes to a person’s overall capability when challenged. No surprise here, of course. We’ve long known that daily exercise is one of the keys to a happy life.\n\n10. Practice mindfulness\nMindfulness – particularly the ability to be with oneself – helps a child set their head in a ‘neutral’ position when faced with difficulties. In a neutral zone, we are neither positive nor negative, merely aware and reacting. \n\n",
                    UserId = user.Id,
                    Date = DateTime.Parse("04/20/2020")
                },
                new BlogPost()
                {
                    Id = 4,
                    Title = "6 Tips for High School Students to Beat Stress",
                    Blog = "It’s no wonder that many high school students feel stressed. To a certain extent, this is normal and expected— everyone experiences stress, and many challenging and valuable experiences will also be unavoidably stressful. Stress can often be part of the experience of growth, and it’s not something you can or should totally avoid.\n  \nWhile feeling stressed in high school may be a natural response to a busy time in your life, you don’t have to resign yourself to its negative effects. There are ways to work on managing your stress that can help you to stay healthy as you pursue your dreams. Below, you’ll find a few of our favorite approaches for dealing with the stress of the high school experience.\n \n \n1.\tGive yourself a break.\nDon’t feel bad about setting aside time in your life to do things that you enjoy and that make you happy, whether or not they seem “productive.” In fact, you should feel good about taking breaks—it’s an essential part of taking care of yourself. All of us need time to rest and refuel.\n \n2.\tStay organized and create a good workspace.\nCleaning your room, or otherwise organizing your spaces and belonging, can be an annoying task, and teenagers are notorious for the lengths they’ll go to to avoid tidying up. However, taking some time to keep things neat can pay off later in terms of stress relief.\n \n \n3.\tTry some stereotypical relaxation activities.\nLighting a candle, having a cup of tea, or taking a bubble bath may seem like cliched approaches to managing stress, but there’s a reason why these activities are so popular. First, they engage your senses, potentially providing a potent distraction from your worries. Second, they’re just plain enjoyable, making them particularly pleasant ways to take a break.\n \n4.\tGet outside and get moving.\nGetting outside, exercising, or participating in some other kind of physical activity can be a great distraction from stressful thoughts and tasks. Tiring yourself out physically can also help you to sleep better, and as we’ll discuss in greater detail below, quality sleep is a valuable thing.\n \n5.\tDevelop better sleep habits. \nMaintaining good sleep hygiene is hard. As a high school student, you don’t have a lot of control over your schedule— school starts at a certain time, extracurriculars and part-time jobs may dominate your after-school hours, and then there’s homework, a social life, and family obligations to juggle.\n\n6.\tFinally, if you’re feeling seriously worried about your stress level, talking to a counselor, therapist, or other professional can really help. A professional’s education and experience allows them to provide you with specific tools, techniques, and insightful suggestions for how you can better manage your stress and look after your own well-being.\n",
                    UserId = user.Id,
                    Date = DateTime.Parse("04/25/2020")
                },
                new BlogPost()
                {
                    Id = 5,
                    Title = "The Importance of Initiative for Students",
                    Blog = "Initiative involves mobilizing and controlling motivation and attention. Many studies have shown that motivation depends on the alignment of many factors, such as understanding how to do an activity or feeling confident one can learn how. Initiative tends to be stronger if an individual is interested in the activity and in working with others.\n\nIn everyday life, there are numerous factors that can impact the strength of motivation, especially the sustained motivation required to reach more challenging goals. In these situations, it’s possible for individuals, for youth in particular, to get overwhelmed, lose interest, or just get bored of the work. Schoolwork, close friends, or romantic relationships can also compete for their attention. For young people to stay focused and motivated many separate pieces need to come together to create a cohesive whole: the task for young people is to learn how to manage and arrange those pieces.\n\nIn order to become an effective “doer,” youth must take action toward a goal and continue that effort over time to see that plan through. The abilities required include not just initiating effort toward a goal, but being able to regulate and sustain that effort through the challenges and setbacks that might be part of the journey.\n\nResearch has long shown that motivation grows when people experience positive relationships, feel competent in what they are doing, and feel that what they are doing matters. Well-run youth programs are rich learning contexts for youth to gain the experiences, skills, and dispositions for initiative. Staff play important roles in providing structures that help youth identify difficult personal goals that motivate their projects, and then staff help as needed to allow youth to experience success in persevering and working toward them.\n\n",
                    UserId = user.Id,
                    Date = DateTime.Parse("05/1/2020")
                },
                new BlogPost()
                {
                    Id = 6,
                    Title = "Is mental health neglected in our children’s schools?",
                    Blog = "The mental health of nearly 5 million kids is neglected on a daily basis.\n\nOf the roughly 50 million children in public school at any given time, upwards of 20% -- that's 5 million kids -- are showing signs of a mental health disorder. A vast majority aren't receiving any help from the school in the form of therapy or counseling, which raises the question: How can this situation be improved?\n\nThe mental health crisis in our schools is a result of a lack of education on the matter, and a lack of resources to properly mitigate it. Teachers, who are the most hands-on with these students the majority of the time, aren't trained in mental health. And on top of that, they have 25+ other students in that class and dozens of other responsibilities on their plate. They are not equipped with the time, resources, or training necessary to give students with signs of mental health issues the unique attention they deserve. Moreover, mental health education is seldom part of the student’s curriculum, even though parents recognize the importance of the subject.\n\nAnd then there are the school counselors. With each counselor responsible for an average of 500 students, the chances of them recognizing symptoms of mental health issues in a portion of those students are slim. They are also employed to focus primarily on academics, so unless this student is seeing them on a regular basis for matters of academia, the counselor is unlikely to notice changes in behavior or attitude that would signify an underlying disorder.\n\nA school psychologist would be ideal, but it's rare that public schools have full-time specialists in this field on staff.\n\nSo what can be done? And why is it so important that this issue be brought to light?\n\nChildren with mental health issues often have the odds of success stacked against them. Often these ailments negatively affect their ability to learn, or at least their ability to learn at the same pace or in the same way as most of the other students in their classes. These mental health ailments can cause them to feel uncomfortable in classroom settings, discouraging them from speaking up or participating, and even causing them to have a harder time building relationships with others. Their mental health issues can be an upsetting distraction, contributing to their feelings of isolation and loneliness. Many children in this situation feel like no one understand them or is looking out for them.\n\nTeachers are the people most likely to recognize the sign in their students, but if they don't have the time or education to properly approach the situation and cater specifically to the needs of that student, then how can they help once they pick up on a problem? A very simple way to open the door to a healthier education for these students would be for the teacher to approach the child directly, asking how they're feeling or if they need help with anything. If no one is asking the children if something is wrong, it'll be a rare occasion that the child opens up to anyone about it. Something as simple as this conversation could increase their drive to do well in school, while also giving them the space to talk about what's bothering them.\n\nThe National Association on Mental Illness reports that half of all chronic mental illness begins by 14 years of age. It's imperative to identify and address it as early as possible, and school staff is in the perfect position to identify early signs of mental illness. If teachers are encouraged by the school districts and administrators to pay attention to the mental health of their students, and given a clear course of action to get the child help, then perhaps we can work toward a more safe and stable educational environment for these children.\n\nWith all eyes paying attention, from home to school and back home again, there is a strong promise of a better tomorrow for children in our public schools. After all, it takes a village.",
                    Date = DateTime.Parse("05/3/2020"),
                    UserId = user.Id
                },
                new BlogPost()
                {
                    Id = 7,
                    Title = "Tips for Coping with Depression",
                    Blog = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Feugiat nisl pretium fusce id. Maecenas pharetra convallis posuere morbi leo urna molestie. Amet commodo nulla facilisi nullam. Volutpat diam ut venenatis tellus. Pellentesque elit ullamcorper dignissim cras tincidunt lobortis. Quis auctor elit sed vulputate mi. Condimentum id venenatis a condimentum vitae sapien. Aliquet porttitor lacus luctus accumsan tortor. Nisl purus in mollis nunc sed id. Penatibus et magnis dis parturient montes nascetur ridiculus. Quis blandit turpis cursus in hac habitasse. Vitae congue eu consequat ac felis donec. Pulvinar mattis nunc sed blandit libero.\n\nEgestas integer eget aliquet nibh praesent tristique. Tempus egestas sed sed risus pretium quam. Morbi leo urna molestie at elementum. Nibh praesent tristique magna sit amet purus gravida quis. Porta nibh venenatis cras sed felis eget velit. Phasellus vestibulum lorem sed risus. Proin libero nunc consequat interdum varius sit. Eu ultrices vitae auctor eu augue ut lectus. Nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus. Ut ornare lectus sit amet. Sem nulla pharetra diam sit amet nisl suscipit adipiscing. Lacus sed viverra tellus in hac habitasse platea. Sit amet dictum sit amet justo donec enim diam vulputate. Pharetra pharetra massa massa ultricies mi quis hendrerit dolor. Ut tristique et egestas quis ipsum. Mattis nunc sed blandit libero volutpat sed cras ornare. Nulla pellentesque dignissim enim sit amet venenatis.\n\nNunc eget lorem dolor sed viverra. Mi eget mauris pharetra et. Porta nibh venenatis cras sed felis. Convallis posuere morbi leo urna. Pulvinar sapien et ligula ullamcorper malesuada proin libero nunc. Neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing. Blandit turpis cursus in hac. Imperdiet proin fermentum leo vel orci. Turpis tincidunt id aliquet risus feugiat in ante metus. Nisl rhoncus mattis rhoncus urna. Dictum sit amet justo donec enim. Purus in mollis nunc sed id semper risus in.\n\nEget mi proin sed libero enim sed faucibus. Volutpat commodo sed egestas egestas fringilla. Elementum pulvinar etiam non quam lacus suspendisse. Volutpat lacus laoreet non curabitur gravida. Morbi tristique senectus et netus. Vestibulum sed arcu non odio euismod. Non quam lacus suspendisse faucibus interdum posuere lorem ipsum. Non curabitur gravida arcu ac tortor dignissim. Lectus sit amet est placerat in egestas. Porttitor eget dolor morbi non arcu risus quis. Curabitur vitae nunc sed velit dignissim sodales ut. Convallis convallis tellus id interdum velit laoreet id donec ultrices. Nisl pretium fusce id velit ut.\n",
                    Date = DateTime.Parse("05/10/2020"),
                    UserId = user.Id
                });

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = 1,
                    Text = "You are a Godsend.",
                    Date = DateTime.Parse("04/21/20"),
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    BlogPostId = 1
                },
                new Comment()
                {
                    Id = 2,
                    Text = "Thank you for this advice.",
                    Date = DateTime.Parse("04/22/20"),
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    BlogPostId = 2
                },
                new Comment()
                {
                    Id = 3,
                    Text = "This is great stuff.",
                    Date = DateTime.Parse("04/21/20"),
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    BlogPostId = 3
                },
                 new Comment()
                 {
                     Id = 4,
                     Text = "You are a Godsend.",
                     Date = DateTime.Parse("04/25/20"),
                     UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 4
                 },
                new Comment()
                {
                    Id = 5,
                    Text = "Thank you for this advice.",
                    Date = DateTime.Parse("05/1/20"),
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    BlogPostId = 5
                },
                new Comment()
                {
                    Id = 6,
                    Text = "This is great stuff.",
                    Date = DateTime.Parse("05/23/20"),
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    BlogPostId = 6
                },
                 new Comment()
                 {
                     Id = 7,
                     Text = "This is great stuff.",
                     Date = DateTime.Parse("05/10/20"),
                     UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 7
                 },
                 new Comment()
                 {
                     Id = 8,
                     Text = "This is great stuff.",
                     Date = DateTime.Parse("04/11/20"),
                     UserId = "10000002 - ffff - ffff - ffff - ffffffffffff",
                     BlogPostId = 1
                 }, new Comment()
                 {
                     Id = 9,
                     Text = "Great advice.",
                     Date = DateTime.Parse("04/15/20"),
                     UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 2
                 }, new Comment()
                 {
                     Id = 10,
                     Text = "This is great stuff.",
                     Date = DateTime.Parse("04/20/20"),
                     UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 3
                 },
                 new Comment()
                 {
                     Id = 11,
                     Text = "Wonderful Advice.",
                     Date = DateTime.Parse("04/25/20"),
                     UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 4
                 },
                 new Comment()
                 {
                     Id = 12,
                     Text = "This is great stuff.",
                     Date = DateTime.Parse("05/01/20"),
                     UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 5
                 }, new Comment()
                 {
                     Id = 13,
                     Text = "Great advice.",
                     Date = DateTime.Parse("05/3/20"),
                     UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 6
                 }, new Comment()
                 {
                     Id = 14,
                     Text = "Lovely Advice.",
                     Date = DateTime.Parse("05/10/20"),
                     UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 7
                 },
                  new Comment()
                  {
                      Id = 15,
                      Text = "This is great stuff.",
                      Date = DateTime.Parse("04/11/20"),
                      UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                      BlogPostId = 1
                  }, new Comment()
                  {
                      Id = 16,
                      Text = "Great advice.",
                      Date = DateTime.Parse("04/15/20"),
                      UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                      BlogPostId = 2
                  }, new Comment()
                  {
                      Id = 17,
                      Text = "This is great stuff.",
                      Date = DateTime.Parse("04/20/20"),
                      UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                      BlogPostId = 3
                  },
                 new Comment()
                 {
                     Id = 18,
                     Text = "Wonderful Advice.",
                     Date = DateTime.Parse("04/25/20"),
                     UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 4
                 },
                 new Comment()
                 {
                     Id = 19,
                     Text = "This is great stuff.",
                     Date = DateTime.Parse("05/01/20"),
                     UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 5
                 }, new Comment()
                 {
                     Id = 20,
                     Text = "Great advice.",
                     Date = DateTime.Parse("05/03/20"),
                     UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 6
                 }, new Comment()
                 {
                     Id = 21,
                     Text = "Lovely Advice.",
                     Date = DateTime.Parse("04/10/20"),
                     UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                     BlogPostId = 7
                 });
            modelBuilder.Entity<ProductReview>().HasData(
                new ProductReview()
                {
                    Id = 1,
                    Comment = "Thanks. Great resource.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 1,
                    Date = DateTime.Parse("04/11/20")
                },
                new ProductReview()
                {
                    Id = 2,
                    Comment = "My class enjoyed this.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 2,
                    Date = DateTime.Parse("04/14/20")
                },
                new ProductReview()
                {
                    Id = 3,
                    Comment = "This is a great idea.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 3,
                    Date = DateTime.Parse("04/15/20")
                },
                new ProductReview()
                {
                    Id = 4,
                    Comment = "So Amazing.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 4,
                    Date = DateTime.Parse("04/15/20")
                },
                new ProductReview()
               {
                    Id = 5,
                    Comment = "Thanks.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 5,
                    Date = DateTime.Parse("04/17/20")
                },
                new ProductReview()
                {
                    Id = 6,
                    Comment = "Love this.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 6,
                    Date = DateTime.Parse("04/17/20")
                },
                new ProductReview()
                {
                    Id = 7,
                    Comment = "This is so inspiring.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 7,
                    Date = DateTime.Parse("04/15/20")
                },
                new ProductReview()
                {
                    Id = 8,
                    Comment = "Cool. Thanks",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 8,
                    Date = DateTime.Parse("04/18/20")
                },
                new ProductReview()
                {
                    Id = 9,
                    Comment = "Love this.",
                    UserId = "10000001-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 9,
                    Date = DateTime.Parse("04/20/20")
                },
                 new ProductReview()
                 {
                     Id = 10,
                     Comment = "Thanks. Great resource.",
                     UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                     ProductId = 1,
                     Date = DateTime.Parse("04/11/20")
                 },
                new ProductReview()
                {
                    Id = 11,
                    Comment = "My class enjoyed this.",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 2,
                    Date = DateTime.Parse("04/14/20")
                },
                new ProductReview()
                {
                    Id = 12,
                    Comment = "This is a great idea.",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 3,
                    Date = DateTime.Parse("04/15/20")
                },
                new ProductReview()
                {
                    Id = 13,
                    Comment = "So Amazing.",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 4,
                    Date = DateTime.Parse("04/15/20")
                },
                new ProductReview()
                {
                    Id = 14,
                    Comment = "Thanks.",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 5,
                    Date = DateTime.Parse("04/17/20")
                },
                new ProductReview()
                {
                    Id = 15,
                    Comment = "Love this.",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 6,
                    Date = DateTime.Parse("04/17/20")
                },
                new ProductReview()
                {
                    Id = 16,
                    Comment = "This is so inspiring.",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 7,
                    Date = DateTime.Parse("04/15/20")
                },
                new ProductReview()
                {
                    Id = 17,
                    Comment = "Cool. Thanks",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 8,
                    Date = DateTime.Parse("04/18/20")
                },
                new ProductReview()
                {
                    Id = 18,
                    Comment = "Love this.",
                    UserId = "10000003-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 9,
                    Date = DateTime.Parse("04/20/20")
                },
                 new ProductReview()
                 {
                     Id = 19,
                     Comment = "Thanks.",
                     UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                     ProductId = 1,
                     Date = DateTime.Parse("04/15/20")
                 },
                new ProductReview()
                {
                    Id = 20,
                    Comment = "Great Idea.",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 2,
                    Date = DateTime.Parse("04/16/20")
                },
                new ProductReview()
                {
                    Id = 21,
                    Comment = "This is a great idea.",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 3,
                    Date = DateTime.Parse("04/15/20")
                },
                new ProductReview()
                {
                    Id = 22,
                    Comment = "Awesome.",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 4,
                    Date = DateTime.Parse("04/26/20")
                },
                new ProductReview()
                {
                    Id = 23,
                    Comment = "Perfect.",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 5,
                    Date = DateTime.Parse("04/25/20")
                },
                new ProductReview()
                {
                    Id = 24,
                    Comment = "Exactly what I needed.",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 6,
                    Date = DateTime.Parse("04/17/20")
                },
                new ProductReview()
                {
                    Id = 25,
                    Comment = "Love this.",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 7,
                    Date = DateTime.Parse("04/27/20")
                },
                new ProductReview()
                {
                    Id = 26,
                    Comment = "Cool. Thanks",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 8,
                    Date = DateTime.Parse("04/18/20")
                },
                new ProductReview()
                {
                    Id = 27,
                    Comment = "Love this.",
                    UserId = "10000002-ffff-ffff-ffff-ffffffffffff",
                    ProductId = 9,
                    Date = DateTime.Parse("04/20/20")
               });


        }

       
    }
}










