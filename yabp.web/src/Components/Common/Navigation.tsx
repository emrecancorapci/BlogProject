import { useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../../Context/AuthContext';

/**
 * @description `Navigation` bar for the top of the page.
 * @return {JSX.Element} The navigation bar
 */

function Navigation (): JSX.Element {
  const { auth, setAuth } = useContext(AuthContext);

  const onClickLogout = (): void => {
    sessionStorage.removeItem('user')
    setAuth(false)
  }

  const userButton = (): JSX.Element => {
    if (auth) {
      return (
        (<button
          className="btn c-bg-lighter border-0 fw-bold"
          onClick={() => { onClickLogout(); }}>
          Logout
        </button>)
      )
    } else {
      return (
        (<Link to={'/login'}>
          <button className="btn c-bg-lighter border-0 fw-bold">
            Login
          </button>
        </Link>)
      )
    }
  };

  return (
    <nav className="navbar navbar-expand-lg navbar-dark c-bg-dark">
      <div className="container">
        <Link to={'/'}>
          <div className="navbar-brand fw-bolder">{import.meta.env.VITE_API_TITLE}</div>
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
            {userButton()}
          </div>
        </div>
      </div>
    </nav>
  )
}

export default Navigation
