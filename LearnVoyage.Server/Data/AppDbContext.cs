using System;
using Microsoft.EntityFrameworkCore;
using LearnVoyage.Server.Models;

namespace LearnVoyage.Server.Data;

public class AppDbContext : DbContext
{
    //　コンストラクタ
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }//DbContextOptionsはDriveManager的なもの

    // DBのテーブルの操作のための変数と型の設定
    public DbSet<User> Users => Set<User>();
    public DbSet<LearnVoyage.Server.Models.Task> Tasks => Set<LearnVoyage.Server.Models.Task>();
    public DbSet<Review> Reviews => Set<Review>();

    // override 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Task の自己参照設定（SubTasks）
        modelBuilder.Entity<LearnVoyage.Server.Models.Task>()
        .HasMany(t => t.SubTasks)//Entityは複数の子を持つという設定 Linqで自動で親子関係を認識して取得するための設定
        .WithOne()// 子から見て親は1人という設定　親-子の関係
        .HasForeignKey("ParentTaskId")// foregin keyで管理する
        .OnDelete(DeleteBehavior.NoAction); // Cascade を NoAction に変更 //親が消えると子も消滅する
    }

}