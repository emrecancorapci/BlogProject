import React, {useState} from 'react';
import PropTypes from 'prop-types';
import axios from 'axios';
import {Alert} from 'react-bootstrap';
import {getToken} from '../../Functions/User';

function AddComment({postId, parentId}) {
  const [form, setForm] = useState([]);
  const [emptyError, setEmptyError] = useState('');

  const user = getToken();

  const onChangeInput = (event) => {
    if (event.target.name === 'content') {
      setEmptyError('');
    }

    setForm({...form, [event.target.name]: event.target.value});
  };

  const onSubmitForm = (event) => {
    event.preventDefault();

    form.authorId = user.id;
    form.postId = postId;
    form.parentId = parentId;

    if (form.content === '') {
      console.log('Fill the comment field.');
      setEmptyError(...'Fill the comment field.');
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
      {user != null &&
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
        <input
          type="text"
          name="parentId"
          value={form.parentId}
          hidden />
        <div className="btn">
          <button>Add</button>
        </div>
      </div>}

      {emptyError != '' &&
      <Alert variant='danger'>
        {emptyError}
      </Alert>}
    </form>
  </>
  );
}

AddComment.propType = {
  user: PropTypes.object,
  content: PropTypes.string,
  postId: PropTypes.number,
  authorId: PropTypes.number,
};

export default AddComment;
