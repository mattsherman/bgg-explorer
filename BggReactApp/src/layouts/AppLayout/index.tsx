import { Outlet } from 'react-router';

import { MainMenu } from '../../components/MainMenu';

import classes from './index.module.css';

export function AppLayout() {
  return (
    <div className={classes['app-layout']}>
      <section className={classes['sidebar']}>
        <MainMenu />
      </section>
      <main className={classes['main']}>
        <Outlet />
      </main>
    </div>
  );
}
