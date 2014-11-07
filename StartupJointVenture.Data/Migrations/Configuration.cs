namespace StartupJointVenture.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StartupJointVenture.Models;


    public sealed class Configuration : DbMigrationsConfiguration<JointVentureDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JointVentureDbContext context)
        {
            if (!context.Categories.Any())
            {
                //IList<Category> categories = new List<Category>();
                //categories.Add(new Category() { Name = "Online ideas" });
                //categories.Add(new Category() { Name = "Mobile ideas" });
                //categories.Add(new Category() { Name = "Service ideas" });
                //categories.Add(new Category() { Name = "Social business ideas" });

                IList<Category> categories = new List<Category>();
                categories.Add(new Category() { Name = "Online ideas" });
                categories.Add(new Category() { Name = "Mobile ideas" });
                categories.Add(new Category() { Name = "Service ideas" });
                categories.Add(new Category() { Name = "Social business ideas" });


                context.Categories.AddOrUpdate(categories.ToArray());

                User user = new User() { UserName = "Anonimous" };

                IList<Idea> ideas = new List<Idea>();

                ideas.Add(new Idea()
                {
                    Category = categories[2],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "International public transportation search service",
                    Content = "It will be nice to have some worldwide site with searching in databases of local transportation services. For example I want to travel from London to Birmingham and doesn't matter with what type of vehicle and providing company. It's pretty difficult to search such things when you are foreigner and don't know anything about local transportation companies. The example is from Britain but it should be available to search for every country and even cross-country. Some sorts of results like \"most economy transport\" or \"fastest transport\" would be also nice."
                });
                ideas.Add(new Idea()
                {
                    Category = categories[2],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "Time barter",
                    Content = "Everyone is good at something. How about a website that would allow time barter - I will program 2 hours anything for somebody if he/she helps me for 2 hours with painting my flat. Everyone then can do what he loves and everything gets done."
                });
                ideas.Add(new Idea()
                {
                    Category = categories[0],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "Intelligent domain name generator",
                    Content = "I often spend hours trying to find out cool and available domain name for my website. There are some services to generate domain name, but it's usually lame - just random number or word added to the end. What I am looking for is an intelligent generator - that would automatically find synonyms and related words that are actually really usable and meaningful."
                });
                ideas.Add(new Idea()
                {
                    Category = categories[1],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "Graphical restaurant reservation system",
                    Content = "A reservation system for pubs and restaurants that would allow you to see a graphical layout of the establishment. You would see what tables are available at what times and you'd be able to book a specific table for a specific time. You could do it on the web or using a mobile app without needing to call the restaurant. You can pick your seats on a plane, why not a restaurant?"
                });
                ideas.Add(new Idea()
                {
                    Category = categories[1],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "Connect EAN codes with product database",
                    Content = "Would be great to have a database of EAN codes on the food and other products so online and mobile applications can be built easily. Just imagine pointing your camera on the EAN code and you know how much it costs in online shops, what is an avarage price or what are the user references."
                });
                ideas.Add(new Idea()
                {
                    Category = categories[1],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "GPS with gas prices",
                    Content = "When driving I want to know what are the current prices at the nearest few gas stations in order to choose the cheapest one. Somebody do it at least for Europe when it changes quickly when you are passing several countries in a few hours."
                });
                ideas.Add(new Idea()
                {
                    Category = categories[0],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "Real-estate crowdfunding platform",
                    Content = "Real estate crowdfunding platform, where participants have an interest in a carefully selected real estate commission, will go to refurbishing real estate and auction / estate trustee. We renovate the buildings and put them in the public sale profits will be divided among the crowd."
                });
                ideas.Add(new Idea()
                {
                    Category = categories[0],
                    DateCreated = DateTime.Now,
                    Author = user,
                    Title = "Personal Teacher",
                    Content = "We are at a turning point in the Education history. The online eduction is exploding, and the traditional education system will have to update itself very soon. \n I am dreaming of a personal teacher, a physical tool that you can carry with you everywhere, that will learn about you and your best learning method (everybody is not equal, some will learn better by listening, other by reading, etc), and then offer you the best learning program ever.\n Every \"teacher\" would be connected to a cloud, and they would be able to share informations between them, which will allow us to find relevant partners for the learners, people wanting to learn the same things and living relatively close from each other. \n This will require huge efforts to realize: an online platform + restful apis, a robot, etc. \n But I believe that this would be one of the best inventions for the decades to come."
                });

                context.Ideas.AddOrUpdate(ideas.ToArray());
            }

        }
    }
}
