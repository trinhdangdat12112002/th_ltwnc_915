using Microsoft.AspNetCore.Mvc;

public class AuthorRepository
{
    public List<Author> authors = new List<Author>() {
        new Author
            {
                Id = 1,
                sFirstName = "Test",
                sLastName = "Test",
            },
            new Author
            {
                Id = 2,
                sFirstName = "Trinh",
                sLastName = "Dat",
            }
        };

    public Author GetAuthor(int id)
    {
        return authors.FirstOrDefault(authors => authors.Id == id);
    }

    public List<Author> GetAuthors(int pageNumber = 1)
    {
        int pageSize = 10;
        int skip = pageSize * (pageNumber - 1);
        if (authors.Count < pageSize)
        {
            pageSize = authors.Count;

        }
        return authors
        .Skip(skip)
        .Take(pageSize).ToList();
    }

    public List<Author> test() { return authors; }


    public void UpdateAuthor(Author updatedAuthor)
    {
        var existingAuthor = authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
        if (existingAuthor != null)
        {
            existingAuthor.sFirstName = updatedAuthor.sFirstName;
            existingAuthor.sLastName = updatedAuthor.sLastName;
        }
    }

    public void DeleteAuthor(int authorId)
    {
        var existingAuthor = authors.FirstOrDefault(a => a.Id == authorId);
        if (existingAuthor != null)
        {
            authors.Remove(existingAuthor);
        }
    }

    public bool CreateAuthor(Author author)
    {
        var result = authors.Where(a => a.sFirstName == author.sFirstName && a.sLastName == author.sLastName);
        if (result != null)
        {
            if (result.Count() == 0)
            {
                int newId = authors.Count > 0 ? authors.Max(a => a.Id) + 1 : 1;
                author.Id = newId;
                authors.Add(author);
                return true;
            }
        }
        return false;
    }
}
