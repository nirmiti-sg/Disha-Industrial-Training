package com.example.project;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class localdb extends SQLiteOpenHelper
{
    public localdb(@Nullable Context context)
    {
        super(context, "localuser", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {
            db.execSQL("create table if not exists drivertbl(mobile TEXT)");
            db.execSQL("create table if not exists customertbl(mobile TEXT)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {

    }

    public void adddriverlogin(String mobile)
    {
        SQLiteDatabase db=getWritableDatabase();
        db.execSQL("insert into drivertbl(mobile)values('"+mobile+"')");
        db.close();
    }
    public void addcustomerlogin(String mobile)
    {
        SQLiteDatabase db=getWritableDatabase();
        db.execSQL("insert into customertbl(mobile)values('"+mobile+"')");
        db.close();
    }
    public String checkdriver()
    {
        SQLiteDatabase db=getReadableDatabase();
        Cursor c=db.rawQuery("select * from drivertbl",null);
        c.moveToFirst();
        if (c.getCount()>0)
        {
            return c.getString(0);
        }
        else
        {
            return null;
        }

    }


    public String checkcustomer()
    {
        SQLiteDatabase db=getReadableDatabase();
        Cursor c=db.rawQuery("select * from customertbl",null);
        c.moveToFirst();
        if (c.getCount()>0)
        {
            return c.getString(0);
        }
        else
        {
            return null;
        }

    }


    public void deldriver()
    {
        SQLiteDatabase db=getWritableDatabase();
        db.execSQL("delete from drivertbl");
        db.close();
    }
    public void delcustomer()
    {
        SQLiteDatabase db=getWritableDatabase();
        db.execSQL("delete from customertbl");
        db.close();
    }


}
