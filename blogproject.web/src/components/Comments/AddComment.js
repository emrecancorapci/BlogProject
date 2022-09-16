import {useState} from 'react';
import React from 'react';
import axios from 'axios';

function AddComment({postId, parentId}) {
  const emptyComment = {
    content: '',
    postId: postId,
    authorId: 2,
    parentId: null,
  };

  const [form, setForm] = useState(emptyComment);
  const onChangeInput = (event) => {
    setForm({...form, [event.target.name]: event.target.value});
  };
  const onSubmitForm = (event) => {
    event.preventDefault();

    if (form.content === '') {
      console.log('Fill all the fields.');
      return false;
    }

    const api = 'https://localhost:7169/api/Comments';

    axios.post(api, form)
        .then(function(response) {
          return response;
        })
        .catch(function(error) {
          return error;
        });
    console.log('Submit');
  };
  return (<>
    <form onSubmit={onSubmitForm}>
      <div>
        <input
          type="text"
          name="content"
          placeholder='Comment Content'
          value={form.content}
          onChange={onChangeInput} />
        <input
          type="text"
          name="postId"
          value={form.postId}
          hidden />
        <input
          type="text"
          name="authorId"
          value={form.authorId}
          hidden />
        {/* {parentId != null && <></>}
        {<input
          type="text"
          name="parentId"
          value={form.parentId}
          hidden />
        } */}
      </div>
      <div className="btn">
        <button>Add</button>
      </div>
    </form>
  </>
  );
}

export default AddComment;
