import React, { useEffect, useState } from 'react';
import { getUserModels } from '@/apis/adminService';
import { GetUserModelResult } from '@/types/admin';
import { IconDots, IconPlus } from '@tabler/icons-react';
import { serverSideTranslations } from 'next-i18next/serverSideTranslations';
import { useTranslation } from 'next-i18next';
import { useThrottle } from '@/hooks/useThrottle';
import { AddUserModelModal } from '@/components/Admin/UserModels/AddUserModelModal';
import { EditUserModelModal } from '@/components/Admin/UserModels/EditUserModelModal';
import { Input } from '@/components/ui/input';
import { Card } from '@/components/ui/card';
import { Button } from '@/components/ui/button';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import { DEFAULT_LANGUAGE } from '@/types/settings';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';

export default function UserModels() {
  const { t } = useTranslation('admin');
  const [isOpen, setIsOpen] = useState({ add: false, edit: false });
  const [selectedUserModel, setSelectedUserModel] =
    useState<GetUserModelResult | null>(null);
  const [selectedModelId, setSelectedModelId] = useState<string>();
  const [userModels, setUserModels] = useState<GetUserModelResult[]>([]);
  const [loading, setLoading] = useState(false);
  const [query, setQuery] = useState<string>('');
  const throttledValue = useThrottle(query, 1000);

  const init = () => {
    getUserModels(query).then((data) => {
      setUserModels(data);
      setIsOpen({ add: false, edit: false });
      setSelectedUserModel(null);
      setLoading(false);
    });
  };

  useEffect(() => {
    init();
  }, [throttledValue]);

  const handleShowAddModal = (item: GetUserModelResult | null) => {
    setSelectedUserModel(item);
    setIsOpen({ add: true, edit: false });
  };

  const handleEditModal = (item: GetUserModelResult, modelId: string) => {
    setSelectedModelId(modelId);
    setSelectedUserModel(item);
    setIsOpen({ add: false, edit: true });
  };

  const handleClose = () => {
    setIsOpen({ add: false, edit: false });
    setSelectedUserModel(null);
  };

  const UserNameCell = (user: GetUserModelResult, rowSpan: number = 1) => {
    return (
      <TableCell rowSpan={rowSpan} className='capitalize'>
        <div className='flex items-center gap-2'>
          <div>{user.userName}</div>
        </div>
      </TableCell>
    );
  };

  const UserBalanceCell = (user: GetUserModelResult, rowSpan: number = 1) => {
    return (
      <TableCell rowSpan={rowSpan}>
        <div className='flex items-center gap-2'>
          <div>{(+user.balance).toFixed(2)}</div>
        </div>
      </TableCell>
    );
  };

  const ModelCell = (
    user: GetUserModelResult,
    modelId: string,
    value: any,
    hover: boolean = false
  ) => {
    return (
      <TableCell
        className={`cursor-pointer ${hover && 'hover:underline'}`}
        onClick={() => handleEditModal(user, modelId)}
      >
        {value || '-'}
      </TableCell>
    );
  };

  const ActionCell = (user: GetUserModelResult, rowSpan: number = 1) => {
    return (
      <TableCell rowSpan={rowSpan}>
        <DropdownMenu>
          <DropdownMenuTrigger>
            <Button variant='ghost'>
              <IconDots size={16} />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent>
            <DropdownMenuItem onClick={() => handleShowAddModal(user)}>
              {t('Add User Model')}
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </TableCell>
    );
  };

  return (
    <>
      <div className='flex flex-col gap-4 mb-4'>
        <div className='flex justify-between gap-3 items-center'>
          <Input
            placeholder={t('Search...')!}
            value={query}
            onChange={(e) => {
              setQuery(e.target.value);
            }}
          />
          <Button
            onClick={() => {
              handleShowAddModal(null);
            }}
            color='primary'
          >
            <IconPlus size={20} />
            {t('Batch add Model')}
          </Button>
        </div>
      </div>
      <Card>
        <Table>
          <TableHeader>
            <TableRow className='pointer-events-none'>
              <TableHead rowSpan={2}>{t('User Name')}</TableHead>
              <TableHead
                rowSpan={2}
                style={{ borderRight: '1px solid hsl(var(--muted))' }}
              >
                {t('Balance')}
              </TableHead>
              <TableHead colSpan={4} className='text-center'>
                {t('Models')}
              </TableHead>
              <TableHead
                rowSpan={2}
                style={{ borderLeft: '1px solid hsl(var(--muted))' }}
                className='w-16'
              >
                操作
              </TableHead>
            </TableRow>
            <TableRow className='pointer-events-none'>
              <TableHead>{t('Model Display Name')}</TableHead>
              <TableHead>{t('Remaining Tokens')}</TableHead>
              <TableHead>{t('Remaining Counts')}</TableHead>
              <TableHead>{t('Expiration Time')}</TableHead>
            </TableRow>
          </TableHeader>

          {userModels.map((user) => (
            <TableBody
              key={user.userId}
              className='tbody-hover'
              style={{ borderTop: '1px solid hsl(var(--muted))' }}
            >
              {user.models.length > 0 ? (
                user.models.map((model, index) => {
                  return (
                    <TableRow
                      key={model.modelId}
                      className={`${
                        index !== user.models.length - 1 && 'border-none'
                      }`}
                    >
                      {index === 0 && UserNameCell(user, user.models.length)}
                      {index === 0 && UserBalanceCell(user, user.models.length)}
                      {ModelCell(user, model.modelId, model.modelName, true)}
                      {ModelCell(user, model.modelId, model.tokens)}
                      {ModelCell(user, model.modelId, model.counts)}
                      {ModelCell(user, model.modelId, model.expires)}
                      {index === 0 && ActionCell(user, user.models.length)}
                    </TableRow>
                  );
                })
              ) : (
                <TableRow
                  key={user.userId}
                  className='cursor-pointer'
                  onClick={() => handleShowAddModal(user)}
                >
                  {UserNameCell(user)}
                  {UserBalanceCell(user)}
                  <TableCell
                    className='text-center text-gray-500'
                    colSpan={5}
                  >
                    {t('Click set model')}
                  </TableCell>
                </TableRow>
              )}
            </TableBody>
          ))}
        </Table>
      </Card>
      <AddUserModelModal
        userModelIds={userModels.map((x: GetUserModelResult) => x.userModelId)}
        selectedModel={selectedUserModel}
        onSuccessful={init}
        onClose={handleClose}
        isOpen={isOpen.add}
      ></AddUserModelModal>

      <EditUserModelModal
        selectedModelId={selectedModelId!}
        selectedUserModel={selectedUserModel}
        onSuccessful={init}
        onClose={handleClose}
        isOpen={isOpen.edit}
      ></EditUserModelModal>
    </>
  );
}

export const getServerSideProps = async ({ locale }: { locale: string }) => {
  return {
    props: {
      ...(await serverSideTranslations(locale ?? DEFAULT_LANGUAGE, [
        'common',
        'admin',
      ])),
    },
  };
};
