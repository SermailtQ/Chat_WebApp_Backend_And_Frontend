namespace ChatApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ChatApp.Infrastructure.Models;

public class ChatDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ConversationEntity> Conversations { get; set; }
    public DbSet<ConversationRoleEntity> ConversationRoles { get; set; }
    public DbSet<ConversationTypeEntity> ConversationTypes { get; set; }
    public DbSet<ParticipantsEntity> ParticipantsEntities { get; set; }
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<MessageReactionsEntity> MessageReactions { get; set; }
    public DbSet<MessageAttachementEntity> MessageAttachements { get; set; }
    public DbSet<FileTypeEntity> FileTypes { get; set; }

    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Participants
        builder.Entity<ParticipantsEntity>()
            .HasKey(p => new { p.ConversationId, p.UserId });

        // Relationships
        builder.Entity<UserEntity>()
            .HasMany(e => e.Roles)
            .WithMany(e => e.Users)
            .UsingEntity(j => j.ToTable("UserRoles")); ;

        builder.Entity<UserEntity>()
            .HasMany(e => e.Participants)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.Entity<UserEntity>()
            .HasMany(e => e.Messages)
            .WithOne(e => e.Sender)
            .HasForeignKey(e => e.SenderId);

        builder.Entity<UserEntity>()
            .HasMany(e => e.MessageReactions)
            .WithOne(e => e.Sender)
            .HasForeignKey(e => e.SenderId);

        builder.Entity<ConversationEntity>()
            .HasMany(e => e.Messages)
            .WithOne(e => e.Conversation)
            .HasForeignKey(e => e.ConversationId);

        builder.Entity<ConversationEntity>()
            .HasMany(e => e.Participants)
            .WithOne(e => e.Conversation)
            .HasForeignKey(e => e.ConversationId);

        builder.Entity<ConversationTypeEntity>()
            .HasMany(e => e.Conversation)
            .WithOne(e => e.Type)
            .HasForeignKey(e => e.Conversati﻿onTypeId);

        builder.Entity<ConversationRoleEntity>()
            .HasMany(e => e.Participants)
            .WithOne(e => e.ConversationRole)
            .HasForeignKey(e => e.ConversationRoleId);

        builder.Entity<MessageEntity>()
            .HasMany(e => e.MessageReactions)
            .WithOne(e => e.Message)
            .HasForeignKey(e => e.MessageId);

        builder.Entity<MessageEntity>()
            .HasMany(e => e.Attachements)
            .WithOne(e => e.Message)
            .HasForeignKey(e => e.MessageId);

        builder.Entity<MessageEntity>()
            .HasMany(e => e.Replys)
            .WithOne(e => e.Reply)
            .HasForeignKey(e => e.ReplyId);

        builder.Entity<FileTypeEntity>()
            .HasMany(e => e.Attachements)
            .WithOne(e => e.FileType)
            .HasForeignKey(e => e.FileTypeId);

        base.OnModelCreating(builder);
    }
}