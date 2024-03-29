using BlazorCommerceWebApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCommerceWebApp.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "AK-47",
                    Description = "The AK-47, officially known as the Avtomat Kalashnikova (Russian: Автомат Калашникова, lit. 'Kalashnikov's automatic [rifle]'; also known as the Kalashnikov or just AK), is a gas-operated assault rifle that is chambered for the 7.62\u00d739mm cartridge. Developed in the Soviet Union by Russian small-arms designer Mikhail Kalashnikov, it is the originating firearm of the Kalashnikov (or \"AK\") family of rifles.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/65/AK-47_type_II_noBG.png",
                    Price = 9.99m
                },
                new Product
                {
                    Id = 2,
                    Name = "Das Kapital",
                    Description = "Capital: A Critique of Political Economy (German: Das Kapital. Kritik der politischen Ökonomie), also known as Capital, is a foundational theoretical text in materialist philosophy and critique of political economy written by Karl Marx, published as three volumes in 1867, 1885, and 1894. The culmination of his life's work, the text contains Marx's analysis of capitalism, to which he sought to apply his theory of historical materialism \"to lay bare the economic laws of modern society\", following from classical political economists such as Adam Smith, Jean-Baptiste Say, David Ricardo and John Stuart Mill. The text's second and third volumes were completed from Marx's notes after his death and published by his colleague Friedrich Engels. Das Kapital is the most cited book in the social sciences published before 1950.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8d/Zentralbibliothek_Z%C3%BCrich_Das_Kapital_Marx_1867.jpg",
                    Price = 4.99m
                },
                new Product
                {
                    Id = 3,
                    Name = "Gas Mask",
                    Description = "A gas mask is an item of personal protective equipment used to protect the wearer from inhaling airborne pollutants and toxic gases. The mask forms a sealed cover over the nose and mouth, but may also cover the eyes and other vulnerable soft tissues of the face. Most gas masks are also respirators, though the word gas mask is often used to refer to military equipment (such as a field protective mask), the scope used in this article. The gas mask only protects the user from digesting,[citation needed][clarification needed] inhaling, and contact through the eyes (many agents affect through eye contact). Most combined gas mask filters will last around 8 hours in a biological or chemical situation. Filters against specific chemical agents can last up to 20 hours. ",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/74/%D0%91%D0%98%D0%9E%D0%A2-2019_%D0%9F%D0%BE%D0%BB%D0%BD%D0%B0%D1%8F_%D0%BC%D0%B0%D1%81%D0%BA%D0%B0_%D1%81_%D1%84%D0%B8%D0%BB%D1%8C%D1%82%D1%80%D0%B0%D0%BC%D0%B8_%D0%BE%D1%82_%D0%B3%D0%B0%D0%B7%D0%BE%D0%B2.jpg",
                    Price = 1.99m
                }
            );
    }
    
    public DbSet<Product> Products { get; set; }
        
    
    
}