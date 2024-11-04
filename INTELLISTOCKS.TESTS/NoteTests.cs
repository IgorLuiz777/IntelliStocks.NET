using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using INTELLISTOCKS.MODELS.db;
using INTELLISTOCKS.MODELS.note;
using INTELLISTOCKS.REPOSITORY;

public class NoteTests
{
    private FIAPDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<FIAPDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new FIAPDbContext(options);
    }

    [Fact]
    public async Task GetAllNotes_ReturnsAllNotes()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var repository = new NoteRepository(context);

        context.Note.AddRange(
            new Note { ID = 1, Title = "Note 1", Content = "Content 1", CreatedDate = DateTime.Now },
            new Note { ID = 2, Title = "Note 2", Content = "Content 2", CreatedDate = DateTime.Now }
        );
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetAll();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Note 1", result[0].Title);
    }

    [Fact]
    public async Task GetNoteById_ReturnsNote_WhenNoteExists()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var repository = new NoteRepository(context);

        var note = new Note { ID = 1, Title = "Test Note", Content = "Content", CreatedDate = DateTime.Now };
        context.Note.Add(note);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Note", result.Title);
    }

    [Fact]
    public async Task CreateNote_AddsNoteToDatabase()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var repository = new NoteRepository(context);

        var note = new Note { ID = 3, Title = "New Note", Content = "New Content", CreatedDate = DateTime.Now };

        // Act
        var createdNote = await repository.Create(note);

        // Assert
        Assert.Equal(note.ID, createdNote.ID);
        Assert.Equal(1, context.Note.Count());
    }

    [Fact]
    public async Task UpdateNote_UpdatesNoteInDatabase()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var repository = new NoteRepository(context);

        var note = new Note { ID = 4, Title = "Old Title", Content = "Old Content", CreatedDate = DateTime.Now };
        context.Note.Add(note);
        await context.SaveChangesAsync();

        // Act
        note.Title = "Updated Title";
        await repository.Update(note);

        // Assert
        var updatedNote = await context.Note.FindAsync(4);
        Assert.Equal("Updated Title", updatedNote.Title);
    }

    [Fact]
    public async Task DeleteNote_RemovesNoteFromDatabase()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var repository = new NoteRepository(context);

        var note = new Note { ID = 5, Title = "Delete Note", Content = "Delete Content", CreatedDate = DateTime.Now };
        context.Note.Add(note);
        await context.SaveChangesAsync();

        // Act
        await repository.Delete(note.ID);

        // Assert
        var deletedNote = await context.Note.FindAsync(note.ID);
        Assert.Null(deletedNote);
    }
}
