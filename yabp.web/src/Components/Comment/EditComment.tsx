export {}
// import { useState } from 'react';
// import axios from 'axios';

// import { getUser } from '../../Functions/User';
// import getApi from '../../Functions/Common/getApi';

// /**
//  * A react component which has a form to edit comment
//  * @param {Number} postId - Post id
//  * @returns {JSX.Element} A comment edit form
//  */

// function EditComment ({ postId, parentId }: {
//   postId: number,
//   parentId: number}) : JSX.Element {
//   const [form, setForm] = useState([]);

//   const onChangeInput = (event) => {
//     setForm({...form, [event.target.name]: event.target.value});
//   };

//   const onSubmitForm = (event) => {
//     event.preventDefault();

//     if (form.content === '') {
//       console.log('Fill all the fields.');
//       return false;
//     }

//     const user = getUser();
//     form.authorId = user.id;

//     const api = getApi('Comments');

//     axios.post(api, form)
//         .then(function(response) {
//           return response;
//         })
//         .catch(function(error) {
//           return error;
//         });
//     console.log('Submit');
//   };
//   return (<>
//     <form onSubmit={onSubmitForm}>
//       <div>
//         <input
//           type="text"
//           name="content"
//           placeholder='Comment Content'
//           value={form.content}
//           onChange={onChangeInput} />
//       </div>
//       <div className="btn">
//         <button>Add</button>
//       </div>
//     </form>
//   </>
//   );
// }

// export default EditComment;
