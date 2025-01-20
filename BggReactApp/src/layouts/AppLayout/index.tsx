import { Outlet } from 'react-router';

import { MainSidebar } from '../../components/MainSidebar';

import classes from './index.module.css';

export function AppLayout() {
  return (
    <div className={classes['app-layout']}>
      <section className={classes['sidebar']}>
        <MainSidebar />
      </section>
      <main className={classes['main']}>
        <Outlet />
      </main>
    </div>
  );
}
