import { useEffect, useState } from "react";
import axios from "axios";

function GetUserName({ id }) {
  const [user, setUser] = useState([]);

  useEffect(() => {
    axios(`https://localhost:7169/api/Users/${id}`)
      .then((response) => setUser(response.data))
      .catch((event) => console.log(event));
  }, [id]);
  return <>{user.username}</>;
}

export default GetUserName;
