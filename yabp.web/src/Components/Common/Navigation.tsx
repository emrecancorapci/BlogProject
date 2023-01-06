import { useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../../Context/AuthContext';

/**
 * @description `Navigation` bar for the top of the page.
 * @param {string} title - The title of the page
 * @param {boolean} auth - Whether the user is authenticated
 * @param {function} setAuth - Function to set the authentication state
 * @return {JSX.Element} The navigation bar
 */

function Navigation ({
  title
}: {
  title: string
}): JSX.Element {
  const { auth, setAuth } = useContext(AuthContext);
  const onClickLogout = (): void => {
    sessionStorage.removeItem('user')
    setAuth(false)
  }

  return (
    <nav className="navbar navbar-expand-lg navbar-dark c-bg-dark">
      <div className="container">
        <Link to={'/'}>
          <div className="navbar-brand fw-bolder">{title}</div>
        </Link>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#headerNavbar"
          aria-controls="headerNavbar"
          aria-expanded="false"
          aria-label="Toggle navigation">
          <span className="navbar-toggler-icon" />
        </button>

        <div className="collapse navbar-collapse" id="headerNavbar">
          <div className="navbar-nav me-auto">
            <div className="col">
              <Link to={'/'}>
                <div className="nav-link fw-bolder">Home</div>
              </Link>
            </div>
          </div>
          <div className="me-5">
            {auth
              ? (<button
                className="btn c-bg-lighter border-0 fw-bold"
                onClick={() => onClickLogout()}>
                Logout
              </button>)
              : (<Link to={'/login'}>
                <button className="btn c-bg-lighter border-0 fw-bold">
                  Login
                </button>
              </Link>)}
          </div>
        </div>
      </div>
    </nav>
  )
}

export default Navigation
