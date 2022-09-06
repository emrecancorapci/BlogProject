import { Link, useSearchParams } from "react-router-dom";

function About(){
    const [searchParams] = useSearchParams();

    const searchTerm = searchParams.get('id') || '';

    return (
      <>
        <main>
          <h2>Who are we?</h2>
          <h3>{searchTerm}</h3>
          <p>
            That feels like an existential question, don't you
            think?
          </p>
        </main>
        <nav>
          <Link to="/">Home</Link>
        </nav>
      </>
    );
  }

export default About