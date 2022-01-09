using System;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace Redis_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var redis = new RedisClient())
            {
                var redisUsers = redis.As<Person>();
                var mohammad = new Person {Id = redisUsers.GetNextSequence(), Name = "Mohammad"};
                var ali = new Person {Id = redisUsers.GetNextSequence(), Name = "Ali"};
                var hassan = new Person {Id = redisUsers.GetNextSequence(), Name = "Hassan" };

                redisUsers.Store(mohammad);
                redisUsers.Store(ali);
                redisUsers.Store(hassan);

                var allThePeople = redisUsers.GetAll();
                Console.WriteLine(allThePeople.Dump());
            }
        }
    }

    public class Person
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
}
