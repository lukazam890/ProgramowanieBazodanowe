CREATE TRIGGER [Tr_GroupDel]
	ON [dbo].[ProductGroups]
	FOR DELETE
	AS
	BEGIN
		UPDATE ProductGroups SET ParentID = NULL WHERE ParentID = (SELECT ID FROM deleted)
		SET NOCOUNT ON
	END