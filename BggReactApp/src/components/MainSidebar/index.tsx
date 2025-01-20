import { NavLink } from 'react-router';

export function MainSidebar() {
  return (
    <div>
      <header>
        <h1>
          <NavLink to="/">BGG Explorer</NavLink>
        </h1>
      </header>
      <menu>
        <li>
          <NavLink to="/hot-items">Hot Items</NavLink>
        </li>
        <li>
          User Collections
          <menu>
            <li>
              <NavLink to="/user/mattsherman/collection">JAM</NavLink>
            </li>
            <li>
              <NavLink to="/user/dccircuit/collection">Andy</NavLink>
            </li>
          </menu>
        </li>
      </menu>
    </div>
  );
}
