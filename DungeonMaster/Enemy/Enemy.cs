namespace DungeonMaster.Enemy;

public class Enemy
{
   public string Name;
   private readonly int _damage;
   public double Hp;

    public Enemy(string name, int damage, double hp)
    {
        this.Name = name;
        this._damage = damage;
        this.Hp = hp;
    }

    public int Attack()
    {
        Random random = new Random();
        int damage = random.Next(1,_damage);
        return damage;
    }
}
   

   