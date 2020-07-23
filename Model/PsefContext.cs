using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PsefApi.Model
{
    public partial class PsefContext : DbContext
    {
        public PsefContext(DbContextOptions<PsefContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apotek> Apotek { get; set; }
        public virtual DbSet<AuditTrail> AuditTrail { get; set; }
        public virtual DbSet<AuditTrailLine> AuditTrailLine { get; set; }
        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<DataLine> DataLine { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DesaKelurahan> DesaKelurahan { get; set; }
        public virtual DbSet<DummyPerusahaan> DummyPerusahaan { get; set; }
        public virtual DbSet<JobRole> JobRole { get; set; }
        public virtual DbSet<JobRoleMember> JobRoleMember { get; set; }
        public virtual DbSet<JobRoleModule> JobRoleModule { get; set; }
        public virtual DbSet<KabKota> KabKota { get; set; }
        public virtual DbSet<Kecamatan> Kecamatan { get; set; }
        public virtual DbSet<OssRegistrationType> OssRegistrationType { get; set; }
        public virtual DbSet<Pemohon> Pemohon { get; set; }
        public virtual DbSet<Perizinan> Perizinan { get; set; }
        public virtual DbSet<Permohonan> Permohonan { get; set; }
        public virtual DbSet<Provinsi> Provinsi { get; set; }
        public virtual DbSet<Sequence> Sequence { get; set; }
        public virtual DbSet<TokenTimer> TokenTimer { get; set; }
        public virtual DbSet<TransactionError> TransactionError { get; set; }
        public virtual DbSet<TransactionItem> TransactionItem { get; set; }
        public virtual DbSet<TransactionSubmission> TransactionSubmission { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserChannel> UserChannel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apotek>(entity =>
            {
                entity.ToTable("apotek", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.DesaKelurahanId);

                entity.HasIndex(e => e.ModifierId);

                entity.HasIndex(e => e.PerizinanId);

                entity.HasIndex(e => e.PermohonanId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Apoteker).HasColumnName("apoteker");

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.DesaKelurahanId).HasColumnName("desa_kelurahan_id");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NoSia).HasColumnName("no_sia");

                entity.Property(e => e.NoSipa).HasColumnName("no_sipa");

                entity.Property(e => e.NoStra).HasColumnName("no_stra");

                entity.Property(e => e.PerizinanId).HasColumnName("perizinan_id");

                entity.Property(e => e.PermohonanId).HasColumnName("permohonan_id");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Apotek)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ApotekCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.DesaKelurahan)
                    .WithMany(p => p.Apotek)
                    .HasForeignKey(d => d.DesaKelurahanId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.ApotekModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Perizinan)
                    .WithMany(p => p.Apotek)
                    .HasForeignKey(d => d.PerizinanId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Permohonan)
                    .WithMany(p => p.Apotek)
                    .HasForeignKey(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.ToTable("audit_trail", "sch_psef");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Submodule).HasColumnName("submodule");
            });

            modelBuilder.Entity<AuditTrailLine>(entity =>
            {
                entity.ToTable("audit_trail_line", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.AuditTrailLine)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditTrailLine)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.ToTable("badge", "sch_psef");

                entity.HasIndex(e => e.JobRoleId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Background).HasColumnName("background");

                entity.Property(e => e.BadgeId).HasColumnName("badge_id");

                entity.Property(e => e.ExpiryTime).HasColumnName("expiry_time");

                entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");

                entity.Property(e => e.Text).HasColumnName("text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.JobRole)
                    .WithMany(p => p.Badge)
                    .HasForeignKey(d => d.JobRoleId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Badge)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Data>(entity =>
            {
                entity.ToTable("data", "sch_psef");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Submodule).HasColumnName("submodule");
            });

            modelBuilder.Entity<DataLine>(entity =>
            {
                entity.ToTable("data_line", "sch_psef");

                entity.HasIndex(e => e.DataId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Data)
                    .WithMany(p => p.DataLine)
                    .HasForeignKey(d => d.DataId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.DataId);

                entity.HasIndex(e => e.DepartmentId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Data)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.DataId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.InverseDepartmentNavigation)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<DesaKelurahan>(entity =>
            {
                entity.ToTable("desa_kelurahan", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.KecamatanId);

                entity.HasIndex(e => e.ModifierId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.KecamatanId).HasColumnName("kecamatan_id");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.DesaKelurahan)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.DesaKelurahanCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Kecamatan)
                    .WithMany(p => p.DesaKelurahan)
                    .HasForeignKey(d => d.KecamatanId);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.DesaKelurahanModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<DummyPerusahaan>(entity =>
            {
                entity.ToTable("dummy_perusahaan", "sch_psef");

                entity.HasIndex(e => e.OssTypeId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CapitalSourceType).HasColumnName("capital_source_type");

                entity.Property(e => e.CompanyType).HasColumnName("company_type");

                entity.Property(e => e.Director).HasColumnName("director");

                entity.Property(e => e.LegalEntityType).HasColumnName("legal_entity_type");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Nib).HasColumnName("nib");

                entity.Property(e => e.Npwp).HasColumnName("npwp");

                entity.Property(e => e.OssTypeId).HasColumnName("oss_type_id");

                entity.Property(e => e.Siup).HasColumnName("siup");

                entity.HasOne(d => d.OssType)
                    .WithMany(p => p.DummyPerusahaan)
                    .HasForeignKey(d => d.OssTypeId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<JobRole>(entity =>
            {
                entity.ToTable("job_role", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.DataId);

                entity.HasIndex(e => e.DepartmentId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GlobalRoleLevel).HasColumnName("global_role_level");

                entity.Property(e => e.GlobalRolePermissions).HasColumnName("global_role_permissions");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.No).HasColumnName("no");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.JobRole)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Data)
                    .WithMany(p => p.JobRole)
                    .HasForeignKey(d => d.DataId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.JobRole)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<JobRoleMember>(entity =>
            {
                entity.ToTable("job_role_member", "sch_psef");

                entity.HasIndex(e => e.JobRoleId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");

                entity.Property(e => e.No).HasColumnName("no");

                entity.Property(e => e.RoleLevel).HasColumnName("role_level");

                entity.Property(e => e.RolePermissions).HasColumnName("role_permissions");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.JobRole)
                    .WithMany(p => p.JobRoleMember)
                    .HasForeignKey(d => d.JobRoleId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobRoleMember)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<JobRoleModule>(entity =>
            {
                entity.ToTable("job_role_module", "sch_psef");

                entity.HasIndex(e => e.JobRoleId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.RoleLevel).HasColumnName("role_level");

                entity.Property(e => e.RolePermissions).HasColumnName("role_permissions");

                entity.HasOne(d => d.JobRole)
                    .WithMany(p => p.JobRoleModule)
                    .HasForeignKey(d => d.JobRoleId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<KabKota>(entity =>
            {
                entity.ToTable("kab_kota", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.ModifierId);

                entity.HasIndex(e => e.ProvinsiId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.ProvinsiId).HasColumnName("provinsi_id");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.KabKota)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.KabKotaCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.KabKotaModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Provinsi)
                    .WithMany(p => p.KabKota)
                    .HasForeignKey(d => d.ProvinsiId);
            });

            modelBuilder.Entity<Kecamatan>(entity =>
            {
                entity.ToTable("kecamatan", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.KabKotaId);

                entity.HasIndex(e => e.ModifierId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.KabKotaId).HasColumnName("kab_kota_id");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Kecamatan)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.KecamatanCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.KabKota)
                    .WithMany(p => p.Kecamatan)
                    .HasForeignKey(d => d.KabKotaId);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.KecamatanModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<OssRegistrationType>(entity =>
            {
                entity.ToTable("oss_registration_type", "sch_psef");

                entity.HasIndex(e => e.Kode)
                    .HasName("AK_oss_registration_type_kode")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kode)
                    .IsRequired()
                    .HasColumnName("kode");

                entity.Property(e => e.Nama).HasColumnName("nama");
            });

            modelBuilder.Entity<Pemohon>(entity =>
            {
                entity.ToTable("pemohon", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.LoginUserId);

                entity.HasIndex(e => e.ModifierId);

                entity.HasIndex(e => e.OssTypeId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.ApotekerEmail).HasColumnName("apoteker_email");

                entity.Property(e => e.ApotekerName).HasColumnName("apoteker_name");

                entity.Property(e => e.ApotekerPhone).HasColumnName("apoteker_phone");

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CapitalSourceType).HasColumnName("capital_source_type");

                entity.Property(e => e.CompanyAddress).HasColumnName("company_address");

                entity.Property(e => e.CompanyName).HasColumnName("company_name");

                entity.Property(e => e.CompanyNpwp).HasColumnName("company_npwp");

                entity.Property(e => e.CompanySiup).HasColumnName("company_siup");

                entity.Property(e => e.CompanyType).HasColumnName("company_type");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Director).HasColumnName("director");

                entity.Property(e => e.LegalEntityType).HasColumnName("legal_entity_type");

                entity.Property(e => e.LoginUserId).HasColumnName("login_user_id");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.Nib).HasColumnName("nib");

                entity.Property(e => e.NoSipa).HasColumnName("no_sipa");

                entity.Property(e => e.NoStra).HasColumnName("no_stra");

                entity.Property(e => e.OssTypeId).HasColumnName("oss_type_id");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Pemohon)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.PemohonCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.LoginUser)
                    .WithMany(p => p.PemohonLoginUser)
                    .HasForeignKey(d => d.LoginUserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.PemohonModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.OssType)
                    .WithMany(p => p.Pemohon)
                    .HasForeignKey(d => d.OssTypeId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Perizinan>(entity =>
            {
                entity.ToTable("perizinan", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.ModifierId);

                entity.HasIndex(e => e.PermohonanId)
                    .IsUnique();

                entity.HasIndex(e => e.PreviousId)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");

                entity.Property(e => e.IssueDate).HasColumnName("issue_date");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.NoIzin).HasColumnName("no_izin");

                entity.Property(e => e.PermohonanId).HasColumnName("permohonan_id");

                entity.Property(e => e.PreviousId).HasColumnName("previous_id");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Perizinan)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.PerizinanCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.PerizinanModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Permohonan)
                    .WithOne(p => p.Perizinan)
                    .HasForeignKey<Perizinan>(d => d.PermohonanId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Previous)
                    .WithOne(p => p.InversePrevious)
                    .HasForeignKey<Perizinan>(d => d.PreviousId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Permohonan>(entity =>
            {
                entity.ToTable("permohonan", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.ModifierId);

                entity.HasIndex(e => e.PemohonId);

                entity.HasIndex(e => e.PreviousId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Domain).HasColumnName("domain");

                entity.Property(e => e.IdPermohonan).HasColumnName("id_permohonan");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.PemohonId).HasColumnName("pemohon_id");

                entity.Property(e => e.PreviousId).HasColumnName("previous_id");

                entity.Property(e => e.ProviderName).HasColumnName("provider_name");

                entity.Property(e => e.RegistrationType).HasColumnName("registration_type");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.SystemName).HasColumnName("system_name");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Permohonan)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.PermohonanCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.PermohonanModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Pemohon)
                    .WithMany(p => p.Permohonan)
                    .HasForeignKey(d => d.PemohonId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Previous)
                    .WithMany(p => p.PermohonanNavigation)
                    .HasForeignKey(d => d.PreviousId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Provinsi>(entity =>
            {
                entity.ToTable("provinsi", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.ModifierId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Provinsi)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ProvinsiCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.ProvinsiModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Sequence>(entity =>
            {
                entity.ToTable("sequence", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.DataId);

                entity.HasIndex(e => e.DepartmentId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Format).HasColumnName("format");

                entity.Property(e => e.IRepeatEvery).HasColumnName("i_repeat_every");

                entity.Property(e => e.LastEntrySequence).HasColumnName("last_entry_sequence");

                entity.Property(e => e.LastEntryString).HasColumnName("last_entry_string");

                entity.Property(e => e.LastEntryTime).HasColumnName("last_entry_time");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Repeat).HasColumnName("repeat");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.Sequence)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Data)
                    .WithMany(p => p.Sequence)
                    .HasForeignKey(d => d.DataId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Sequence)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<TokenTimer>(entity =>
            {
                entity.ToTable("token_timer", "sch_psef");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DeleteOnExpired).HasColumnName("delete_on_expired");

                entity.Property(e => e.ExpiryTime).HasColumnName("expiry_time");

                entity.Property(e => e.Types).HasColumnName("types");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TokenTimer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<TransactionError>(entity =>
            {
                entity.ToTable("transaction_error", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.ModifierId);

                entity.HasIndex(e => e.TransactionId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.TransactionError)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TransactionErrorCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.TransactionErrorModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionError)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TransactionItem>(entity =>
            {
                entity.ToTable("transaction_item", "sch_psef");

                entity.HasIndex(e => e.ApotekId);

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.ModifierId);

                entity.HasIndex(e => e.SubmissionId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ApotekId).HasColumnName("apotek_id");

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.ByPrescription).HasColumnName("by_prescription");

                entity.Property(e => e.ConsumerAddress).HasColumnName("consumer_address");

                entity.Property(e => e.ConsumerGender).HasColumnName("consumer_gender");

                entity.Property(e => e.ConsumerId).HasColumnName("consumer_id");

                entity.Property(e => e.ConsumerName).HasColumnName("consumer_name");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.DoctorName).HasColumnName("doctor_name");

                entity.Property(e => e.DoctorRegNo).HasColumnName("doctor_reg_no");

                entity.Property(e => e.Dosage).HasColumnName("dosage");

                entity.Property(e => e.InvoiceNo).HasColumnName("invoice_no");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.PharmacyId).HasColumnName("pharmacy_id");

                entity.Property(e => e.PharmacyName).HasColumnName("pharmacy_name");

                entity.Property(e => e.ProductBrand).HasColumnName("product_brand");

                entity.Property(e => e.ProductCategory).HasColumnName("product_category");

                entity.Property(e => e.ProductType).HasColumnName("product_type");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.SubmissionId).HasColumnName("submission_id");

                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");

                entity.Property(e => e.Uom).HasColumnName("uom");

                entity.HasOne(d => d.Apotek)
                    .WithMany(p => p.TransactionItem)
                    .HasForeignKey(d => d.ApotekId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.TransactionItem)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TransactionItemCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.TransactionItemModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.TransactionItem)
                    .HasForeignKey(d => d.SubmissionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TransactionSubmission>(entity =>
            {
                entity.ToTable("transaction_submission", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.CreatorId);

                entity.HasIndex(e => e.IzinId);

                entity.HasIndex(e => e.ModifierId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.CreatedTime).HasColumnName("created_time");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.IzinId).HasColumnName("izin_id");

                entity.Property(e => e.ModifiedTime).HasColumnName("modified_time");

                entity.Property(e => e.ModifierId).HasColumnName("modifier_id");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.TransactionSubmission)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TransactionSubmissionCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Izin)
                    .WithMany(p => p.TransactionSubmission)
                    .HasForeignKey(d => d.IzinId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Modifier)
                    .WithMany(p => p.TransactionSubmissionModifier)
                    .HasForeignKey(d => d.ModifierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.DataId);

                entity.HasIndex(e => e.DepartmentId);

                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Data)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.DataId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<UserChannel>(entity =>
            {
                entity.ToTable("user_channel", "sch_psef");

                entity.HasIndex(e => e.AuditTrailId);

                entity.HasIndex(e => e.DataId);

                entity.HasIndex(e => e.DepartmentId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditTrailId).HasColumnName("audit_trail_id");

                entity.Property(e => e.Channel).HasColumnName("channel");

                entity.Property(e => e.ChannelUsername).HasColumnName("channel_username");

                entity.Property(e => e.DataId).HasColumnName("data_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.AuditTrail)
                    .WithMany(p => p.UserChannel)
                    .HasForeignKey(d => d.AuditTrailId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Data)
                    .WithMany(p => p.UserChannel)
                    .HasForeignKey(d => d.DataId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.UserChannel)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserChannel)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
