using App.Domain.Core.Entities;

namespace App.Infra.Db
{
	public static class InMemoryDb
	{
        public static User CurrentUser { get; set; }
    }
}