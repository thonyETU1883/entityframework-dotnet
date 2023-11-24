using Npgsql;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace entityframeworklearn.Models;

public class Article{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("idarticle")]
    string idarticle;
    
    [Column("nomarticle")]
    string nomarticle; 

    [Column("prix")]
    double prix;

    [Column("etat")]
    int etat;

    public Article(){}

    public Article(String idarticle,String nomarticle,double prix,int etat){
        this.idarticle = idarticle;
        this.nomarticle = nomarticle;
        this.prix = prix;
        this.etat = etat;
    }

    public Article(String nomarticle,double prix,int etat){
        this.nomarticle = nomarticle;
        this.prix = prix;
        this.etat = etat;
    }

    public String getidarticle(){
        return this.idarticle;
    }

    public void setidarticle(String idarticle){
        this.idarticle = idarticle;
    }

    public String getnomarticle(){
        return this.nomarticle;
    }

    public void setnomarticle(String nomarticle){
        this.nomarticle = nomarticle;
    }

    public double getprix(){
        return this.prix;
    }

    public void setprix(double prix){
        this.prix = prix;
    } 

    public int getetat(){
        return this.etat;
    }

    public void setetat(int etat){
        this.etat = etat;
    }

    //insertion
    public void ajoutarticle(Context context){
        context.article.Add(this);
        context.SaveChanges();
        Console.WriteLine("article inserer");
    }

    public List<Article> getallarticle(Context context){
        List<Article> tousLesArticles = context.article.ToList();
        return tousLesArticles;
    }

    public List<Article> getarticlewhere(Context context,int etat){
        List<Article> articlesFiltres = context.article
        .Where(article => article.etat == etat)
        .ToList();
        return articlesFiltres;
    }

    public List<Article> getarticleorderby(Context context){
        List<Article> articlesorder = context.article
        .OrderBy(article => article.prix)
        .ToList();
        return articlesorder;
    }

    public List<Article> getarticleorderbydesc(Context context){
        List<Article> articlesorder = context.article
        .OrderByDescending(article => article.prix)
        .ToList();
        return articlesorder;
    }

    public Article wherelimit(Context context,String idarticle){
        Article article = context.article
        .Where(article => article.idarticle == idarticle)
        .FirstOrDefault();
        return article;
    }

    public Article getbyid(Context context,String idarticle){
        Article article = context.article.Find(idarticle);
        return article;
    }

    public List<Article> requetepersonnalise(Context context){
        List<Article> resultatsPersonnalises = context.article
        .FromSqlRaw("SELECT vente.*,article.nomarticle,article.prix,article.etat FROM vente JOIN article ON vente.idarticle = article.idarticle")
        .ToList();
        return resultatsPersonnalises;
    }
    
    public void update(Context context,String idarticle){
        Article articleAModifier = context.article.Find(idarticle);
        if (articleAModifier != null)
        {
            articleAModifier.setprix(2000);
            context.Entry(articleAModifier).State = EntityState.Modified;
            context.SaveChanges();
        }
    }      
}