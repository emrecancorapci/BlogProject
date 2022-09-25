import React, {useState} from 'react';
import axios from 'axios';
import {Alert, Form, Button} from 'react-bootstrap';
import {getToken} from '../../Functions/User';

// TODO Not working
function AddPost() {
  const emptyForm = {
    title: '',
    content: '',
    postSummary: '',
    thumbnailUrl: '',
    commentsEnabled: null,
    reactionsEnabled: null,
    categoryId: null,
    authorId: null,
  };

  const [form, setForm] = useState(emptyForm);
  // const [errorText, setErrorText] = useState('');
  // const [error, setError] = useState(false);

  const onChangeInput = (event) => {
    setForm({...form, [event.target.name]: event.target.value});
  };

  const onSubmitForm = (event) => {
    event.preventDefault();

    const api='https://localhost:7169/api/Posts';

    if (form.title === '' || form.content === '') {
      // setError(true);
      // setErrorText('Fill all the fields.');
      return false;
    }

    const user = getToken();

    form.authorId = user.id;
    form.categoryId = 1;

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
    <Form onSubmit={() => onSubmitForm()}>
      <Form.Group className="mb-3">
        <Form.Label>Title</Form.Label>
        <Form.Control
          type="text"
          name="title"
          placeholder="Title"
          value={form.title}
          onChange={onChangeInput} />
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Label>Post</Form.Label>
        <Form.Control
          as="textarea"
          rows={3}
          name="content"
          value={form.content}
          onChange={onChangeInput}/>
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Label>Title</Form.Label>
        <Form.Control
          type="text"
          name="thumbnailUrl"
          placeholder="ThumbnailUrl"
          value={form.thumbnailUrl}
          onChange={onChangeInput} />
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Label>Title</Form.Label>
        <Form.Control
          type="text"
          name="postSummary"
          placeholder="Post Summary"
          value={form.postSummary}
          onChange={onChangeInput} />
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Check
          type="checkbox"
          name="commentsEnabled"
          label="Comments enabled:"
          value={form.commentsEnabled}
          onChange={onChangeInput}
        />
      </Form.Group>
      <Form.Group className="mb-3">
        <Form.Check
          type="checkbox"
          name="reactionsEnabled"
          label="Reactions enabled:"
          value={form.reactionsEnabled}
          onChange={onChangeInput}
        />
      </Form.Group>
      {/* {!error && <></>}
        {<Alert key={variant} variant={variant}>
          {errorText}
        </Alert>} */}
      <Button variant="primary" type="submit">
          Submit
      </Button>
    </Form>
  );
}

export default AddPost;
