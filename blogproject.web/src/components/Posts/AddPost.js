import { useState } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

function AddPost() {
  const [form, setForm] = useState([]);

  const onChangeInput = (event) => {
    setForm({ ...form, [event.target.name]: event.target.value });
  };

  const onSubmitForm = (event) => {
    // Prevent page refresh when form send
    event.preventDefault();

    // Empty field check
    if (form.title === "" || form.content === "") {
      console.log("Fill all the fields.");
      return false;
    }

    // Use function that got from Contacts
    // to save the form data
    axios
      .post("https://localhost:7169/api/Posts", form)
      .then(function (response) {
        return response;
      })
      .catch(function (error) {
        return error;
      });

    console.log("Submit");
  };

  return (
    <>
      <form onSubmit={onSubmitForm}>
        <div>
          <input
            type="text"
            name="title"
            placeholder="Title"
            value={form.title}
            onChange={onChangeInput}
          />
        </div>
        <div>
          <input
            type="text"
            name="content"
            placeholder="Content"
            value={form.content}
            onChange={onChangeInput}
          />
        </div>
        <div>
          <input
            type="text"
            name="thumbnailUrl"
            placeholder="ThumbnailUrl"
            value={form.thumbnailUrl}
            onChange={onChangeInput}
          />
        </div>
        <div>
          <input
            type="text"
            name="postSummary"
            placeholder="Post Summary"
            value={form.postSummary}
            onChange={onChangeInput}
          />
        </div>
        <div>
          <span>Comments enabled:</span>
          <input
            type="checkbox"
            name="commentsEnabled"
            value={form.commentsEnabled}
          />
        </div>
        <div>
          <span>Reactions enabled:</span>
          <input
            type="checkbox"
            name="reactionsEnabled"
            value={form.reactionsEnabled}
          />
        </div>

        <input type="text" name="categoryId" value={1} hidden />
        <input type="text" name="authorId" value={2} hidden />

        <div class="btn">
          <button>Add</button>
        </div>
      </form>
      <Link to={`/Posts`}>Back to Post</Link>
    </>
  );
}

export default AddPost;
