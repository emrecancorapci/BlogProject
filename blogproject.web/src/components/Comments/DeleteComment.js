import axios from 'axios';
import { useEffect, useState } from "react";

function DeleteComment({ id }) {
	const [funcResponse, setFuncResponse] = useState([])

	useEffect(() => {
		const data = sessionStorage.getItem("login")
		const api = `https://localhost:7169/api/Comments/${id}`
		const headers = {
			headers: {"Authorization": `Bearer ${data.token}`}
		};

		axios.delete(api, headers)
			.then(response => setFuncResponse(response));
	}, [id]);

	return funcResponse;
}

export default DeleteComment