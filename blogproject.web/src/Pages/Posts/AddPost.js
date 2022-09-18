import React, {useState} from 'react';
import axios from 'axios';
// import {Alert} from 'react-bootstrap';


function AddPost() {
  const [form, setForm] = useState([]);
  // const [errorText, setErrorText] = useState('');
  // const [error, setError] = useState(false);

  const onChangeInput = (event) => {
    setForm({...form, [event.target.name]: event.target.value});
  };

  const onSubmitForm = (event) => {
    event.preventDefault();

    const api='https://localhost:7169/api/Posts';

    if (form.title === '' || form.content === '') {
      setError(true);
      setErrorText('Fill all the fields.');
      return false;
    }

    axios.post(api, form)
        .then((response) => {
          return response;
        })
        .catch((error) => {
          return error;
        });

    console.log('Submit');
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

        <input type="number" name="categoryId" value={1} hidden />
        <input type="number" name="authorId" value={2} hidden />

        {/* {!error && <></>}
        {<Alert key={variant} variant={variant}>
          {errorText}
        </Alert>} */}

        <div className="btn">
          <button>Add</button>
        </div>
      </form>
    </>
  );
}

export default AddPost;
