import { useState } from 'react'
import axios from 'axios';

function AddComment({ postId, setId }) {
    const emptyComment = {
        content: "",
        postId: postId,
        authorId: 2,
        parentId: null
    }

    const [form, setForm] = useState(emptyComment)

    const onChangeInput = (event) => {
        setForm({ ...form, [event.target.name]: event.target.value });
    }

    const onSubmitForm = (event) => {
        // Prevent page refresh when form send
        event.preventDefault();

        // Empty field check
        if (form.content === "") {
            console.log("Fill all the fields.");
            return false;
        }

        // Use function that got from Contacts
        // to save the form data
        axios.post('https://localhost:7169/api/Comments', form)
            .then(function (response) { return response; })
            .catch(function (error) { return error; });

        setId(postId);

        console.log("Submit");
    }

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
            </div>


            <div class="btn">
                <button>Add</button>
            </div>
        </form>
    </>
    )
}

export default AddComment